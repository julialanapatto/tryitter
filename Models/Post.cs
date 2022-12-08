namespace Tryitter.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Descricao { get; set; }
        public string? ImagemUrl { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}