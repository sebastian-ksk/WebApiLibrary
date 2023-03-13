namespace WebApiLibrary.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public Autor? Author { get; set; }

        public DateTime Created { get; set; }
        = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;

    }
}
