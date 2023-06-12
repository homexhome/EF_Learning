namespace EF_Learning.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int? UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}
