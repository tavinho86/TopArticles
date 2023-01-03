using System.Text.Json.Serialization;

namespace TopArticles.Service
{
    public class ArticleResponse
    {
        [property: JsonPropertyName("page")]
        public int? page { get; set; }

        [property: JsonPropertyName("per_page")]
        public int? per_page { get; set; }

        [property: JsonPropertyName("total")]
        public int? total { get; set; }

        [property: JsonPropertyName("total_pages")]
        public int? total_pages { get; set; }

        [property: JsonPropertyName("data")]
        public List<Datum> data { get; set; }

        public class Datum
        {
            [property: JsonPropertyName("title")]
            public string? title { get; set; }

            [property: JsonPropertyName("url")]
            public string? url { get; set; }

            [property: JsonPropertyName("author")]
            public string? author { get; set; }

            [property: JsonPropertyName("num_comments")]
            public int? num_comments { get; set; }

            [property: JsonPropertyName("story_id")]
            public int? story_id { get; set; }

            [property: JsonPropertyName("story_title")]
            public string? story_title { get; set; }

            [property: JsonPropertyName("story_url")]
            public string? story_url { get; set; }

            [property: JsonPropertyName("parent_id")]
            public int? parent_id { get; set; }

            [property: JsonPropertyName("created_at")]
            public int? created_at { get; set; }
        }
    }
}