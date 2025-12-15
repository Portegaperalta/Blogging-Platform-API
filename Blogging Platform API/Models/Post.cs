namespace Blogging_Platform_API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get;set; }
        public string? Category { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public required User Author { get; set; }
    }
}
