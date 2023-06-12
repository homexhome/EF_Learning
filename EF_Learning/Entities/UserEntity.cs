namespace EF_Learning.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<BookEntity> Books { get; set; }

        public UserEntity() { Books = new(); }
    }
}
