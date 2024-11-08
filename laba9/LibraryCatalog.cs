using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace laba9
{
    public class LibraryCatalog
    {
        private List<Book> _books;

        public LibraryCatalog()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine($"Книга '{book.Title}' добавлена в каталог.");
        }

        public void RemoveBook(string title)
        {
            var bookToRemove = _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
                Console.WriteLine($"Книга '{title}' удалена из каталога.");
            }
            else
            {
                Console.WriteLine($"Книга '{title}' не найдена.");
            }
        }

        public Book FindBookByTitle(string title)
        {
            // Проверяем, что список книг не пустой
            var book = _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book == null)
            {
                Console.WriteLine($"Книга с названием '{title}' не найдена.");
            }
            return book;
        }

        public List<Book> FindBooksByAuthor(string author)
        {
            return _books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void PrintCatalog()
        {
            Console.WriteLine("Каталог библиотеки:");
            foreach (var book in _books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public void BorrowBook(string title)
        {
            var book = FindBookByTitle(title);
            if (book != null)
            {
                book.BorrowBook();
            }
            else
            {
                Console.WriteLine($"Книга '{title}' не найдена в каталоге.");
            }
        }

        public void ReturnBook(string title)
        {
            var book = FindBookByTitle(title);
            if (book != null)
            {
                book.ReturnBook();
            }
            else
            {
                Console.WriteLine($"Книга '{title}' не найдена в каталоге.");
            }
        }

        // Метод для загрузки каталога из XML
        public void LoadFromXml(string filename)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                using (StreamReader reader = new StreamReader(filename))
                {
                    // Десериализуем и проверяем на null
                    var loadedBooks = (List<Book>)serializer.Deserialize(reader);
                    _books = loadedBooks ?? new List<Book>(); // Если десериализация вернула null, создаем новый список
                    Console.WriteLine("Каталог успешно загружен из файла.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке из XML: {ex.Message}");
            }
        }

        // Метод для сохранения каталога в XML
        public void SaveToXml(string filename)
        {
            try
            {
                // Текущая директория
                string path = Path.Combine(Environment.CurrentDirectory, filename);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                using (StreamWriter writer = new StreamWriter(path))
                {
                    serializer.Serialize(writer, _books);
                    Console.WriteLine($"Каталог успешно сохранен в файл: {path}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении в XML: {ex.Message}");
            }
        }
    }
}
