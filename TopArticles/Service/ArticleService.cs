using System.Net.Http.Json;
using TopArticles.DTO;

namespace TopArticles.Service
{
    public class ArticleService
    {
        HttpClient _client;

        public ArticleService()
        {
            ConfigureClient();
        }

        public async Task<List<Article>> GetArticles()
        {
            List<Article> articles = new List<Article>();
            int pageNumber = 1;
            int totalPages = 1;

            do
            {
                HttpResponseMessage response = await _client.GetAsync($"/api/articles?page={pageNumber}");

                if (response.IsSuccessStatusCode)
                {
                    ArticleResponse articleResponse = await response.Content.ReadFromJsonAsync<ArticleResponse>();

                    foreach (ArticleResponse.Datum data in articleResponse.data)
                    {
                        articles.Add(ResponseToDto(data));
                    }

                    pageNumber++;
                    totalPages = articleResponse.total_pages ?? totalPages;
                }
            } while (totalPages >= pageNumber);

            return articles;
        }

        private void ConfigureClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://jsonmock.hackerrank.com/");
        }

        private Article ResponseToDto(ArticleResponse.Datum data)
        {
            return new Article()
            {
                Title = data.title,
                Url = data.url,
                Author = data.author,
                Num_comments = data.num_comments,
                Story_id = data.story_id,
                Story_title = data.story_title,
                Story_url = data.story_url,
                Parent_id = data.parent_id,
                Ccreated_at = data.created_at
            };
        }
    }
}