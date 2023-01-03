namespace TopArticles.DTO
{
    public class Article
    {
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Author { get; set; }
        public int? Num_comments { get; set; }
        public int? Story_id { get; set; }
        public string? Story_title { get; set; }
        public string? Story_url { get; set; }
        public int? Parent_id { get; set; }
        public int? Ccreated_at { get; set; }
        public string? Name { get; set; }
    }
}