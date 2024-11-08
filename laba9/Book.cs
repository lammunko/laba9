using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba9
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        public Book() { }

        public Book(string title, string author, int totalCopies, int availableCopies)
        {
            Title = title;
            Author = author;
            TotalCopies = totalCopies;
            AvailableCopies = availableCopies;
        }

        public void BorrowBook()
        {
            if (AvailableCopies > 0)
            {
                AvailableCopies--;
                Console.WriteLine($"Книга '{Title}' была успешно выдана.");
            }
            else
            {
                Console.WriteLine($"Нет доступных экземпляров книги '{Title}'");
            }
        }

        public void ReturnBook()
        {
            if (AvailableCopies < TotalCopies)
            {
                AvailableCopies++;
                Console.WriteLine($"Книга '{Title}' была возвращена.");
            }
            else
            {
                Console.WriteLine($"Все экземпляры книги '{Title}' уже в библиотеке.");
            }
        }

        public override string ToString()
        {
            return $"{Title} ({Author}), Экземпляры: {TotalCopies}, Доступно: {AvailableCopies}";
        }
    }
}
