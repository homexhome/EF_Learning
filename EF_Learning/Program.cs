using EF_Learning.Entities;
using EF_Learning.Repository;

namespace EF_Learning;

class Program
{
    static void Main(string[] args) {
        using (var db = new Data.AppContext()) {
            var userRepo = new UserRepository(db);
            var bookRepo = new BookRepository(db);

            var user1 = new UserEntity { Name = "А", Email = "А@gmail.com" };
            var user2 = new UserEntity { Name = "B", Email = "B@b.com" };
            var book1 = new BookEntity {
                Name = "Первая книга",
                Author = "Василий Васильевич",
                Genre = "Фантастика",
                Year = 1990
            };
            var book2 = new BookEntity {
                Name = "А если?!",
                Author = "Василий Васильевич",
                Genre = "Фантастика",
                Year = 1995
            };
            var book3 = new BookEntity {
                Name = "О книгах",
                Author = "Петр Петрович",
                Genre = "Драма",
                Year = 1987
            };
            db.Users.Add(user1);
            db.Users.Add(user2);
            db.Books.Add(book1);
            db.Books.Add(book2);
            db.Books.Add(book3);

            user1.Books.Add(book1);
            user1.Books.Add(book3);
            db.SaveChanges();

            bookRepo.GetAllBooksOnUserHands(1);
        }
    }
}