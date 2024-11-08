using laba9;

class Program
{
    static void Main()
    {
        LibraryCatalog catalog = new LibraryCatalog();

        // Добавление книг в каталог
        catalog.AddBook(new Book("Война и мир", "Лев Толстой", 5, 5));
        catalog.AddBook(new Book("Преступление и наказание", "Федор Достоевский", 3, 3));

        // Печать каталога
        catalog.PrintCatalog();

        // Поиск книги по названию
        var book = catalog.FindBookByTitle("Война и мир");
        if (book != null)
            Console.WriteLine($"Найденная книга: {book.ToString()}");

        // Операции с книгами
        catalog.BorrowBook("Война и мир");
        catalog.BorrowBook("Преступление и наказание");

        // Печать каталога после выдачи книги
        catalog.PrintCatalog();

        // Сохранение в XML
        catalog.SaveToXml("library_catalog.xml");

        // Загрузка из XML
        var newCatalog = new LibraryCatalog();
        newCatalog.LoadFromXml("library_catalog.xml");

        // Печать загруженного каталога
        newCatalog.PrintCatalog();
    }
}