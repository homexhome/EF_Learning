using EF_Learning.Entities;

namespace EF_Learning.Repository
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository(Data.AppContext context) : base(context) { }

        public void UpdateUserName(int id, string newName) {
            var user = FindById(id);
            user.Name = newName;
            _appContext.SaveChanges();
        }

        public void FindAllUserBooks(int id) {
            var user = FindById(id);
            Console.WriteLine($"У пользователя {user.Name} находятся : ");
            foreach (var book in user.Books) {
                Console.Write(book.Name);
            }
        }
    }
}
