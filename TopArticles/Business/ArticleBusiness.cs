using TopArticles.DTO;
using TopArticles.Service;

namespace TopArticles.Business
{
    public class ArticleBusiness
    {
        public async Task<List<string>> TopArticles(int limit)
        {
            List<Article> articles = await new ArticleService().GetArticles();
            List<string> articleNames = AdjustArticleNames(articles, limit);

            return articleNames;
        }

        private List<string> AdjustArticleNames(List<Article> articles, int limit)
        {
            foreach (Article article in articles)
            {
                if (!string.IsNullOrWhiteSpace(article.Title))
                {
                    article.Name = article.Title;
                }
                else if (!string.IsNullOrWhiteSpace(article.Story_title))
                {
                    article.Name = article.Story_title;
                }
            }

            articles.RemoveAll(a => string.IsNullOrWhiteSpace(a.Name));

            return articles.OrderByDescending(a => a.Num_comments).ThenByDescending(a => a.Name).Select(a => a.Name).Take(limit).ToList();
        }
    }
}