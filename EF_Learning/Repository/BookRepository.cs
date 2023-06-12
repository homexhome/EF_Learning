using EF_Learning.Entities;

namespace EF_Learning.Repository
{
    public class BookRepository : BaseRepository<BookEntity>
    {
        public BookRepository(Data.AppContext context) : base(context) { }

        public void UpdateYear(int id, int year) {
            var book = FindById(id);
            book.Year = year;
            _appContext.SaveChanges();
        }
        public void SelectGenreAndYear(string genre, int firstYear, int lastYear) {
            var selectedBooks = _appContext.Books.Where(x => x.Genre == genre
                                        && x.Year >= firstYear
                                        && x.Year <= lastYear)
                                                .ToList();
            if (selectedBooks.Count > 0) {
                foreach (var book in selectedBooks) {
                    Console.WriteLine($"В выборке есть {book.Name} {book.Year} года");
                }
            }
            else { Console.WriteLine("Таких книг нет"); };
        }

        public void FindBookByAuthor(string author) {
            var selectedBooks = _appContext.Books.Where(x => x.Author == author).ToList();
            if (selectedBooks.Count > 0) {
                Console.WriteLine($"В нашей библиотеке есть такие книги авторства {author}");
                foreach (var book in selectedBooks) {
                    Console.WriteLine(book.Name);
                }
            }
            else {
                Console.WriteLine("У нас нет книг этого автора");
            }
        }

        public void CountBookByGenre(string genre) {
            var selectedBooks = _appContext.Books.Where(x => x.Author == genre).ToList();
            if (selectedBooks.Count > 0) {
                Console.WriteLine($"В нашей библиотеке есть такие книги жанра : {genre}");
                foreach (var book in selectedBooks) {
                    Console.WriteLine(book.Name);
                }
            }
            else { Console.WriteLine("У нас нет книг этого жанра"); }
        }

        public bool IsBookByAuthorExists(string author, string name) {
            return _appContext.Books.Any(book => book.Author == author && book.Name == name);
        }

        public bool IsBookByAuthorOnHands(string author, string name) {
            return _appContext.Books.Any(book => book.UserId != null);
        }

        public void GetAllBooksOnUserHands(int id) {
            var bookList = _appContext.Books.Where(x => x.UserId == id).ToList();
            if (bookList.Count > 0) {
                Console.WriteLine($"У пользователя на есть книги: ");
                foreach (var book in bookList) {
                    Console.WriteLine(book.Name);
                }
            }
            else { Console.WriteLine("У этого пользователя нет книг"); }
        }

        public List<BookEntity> GetSortedByYearBook() {
            return _appContext.Books.OrderByDescending(x => x.Year).ToList();
        }

        public void GetLastBook() {
            var lastBook = GetSortedByYearBook().First();
            Console.WriteLine($"Последняя вышедшая книга - {lastBook.Name} в {lastBook.Year}");
        }

        public List<BookEntity> GetSortedByNameBook() {
            return _appContext.Books.OrderBy(x => x.Name).ToList();
        }

    }
}
