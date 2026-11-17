using Practicum.Common;

namespace Practicum.Tasks.Level3;

public class Task45_Library : ITask
{
    public string Title => "Библиотека";
    public string Description => "Выдача и возврат книг.";
    public string[] Requirements => new[]
    {
        "Book, Reader и Library",
        "Не больше трёх книг на читателя",
        "Исключения и юнит-тесты"
    };

    public void Run()
    {
        Library library = new Library();
        Reader reader = new Reader("Коля");
        Book first = new Book("Мастер и Маргарита", "Булгаков");
        Book second = new Book("Капитанская дочка", "Пушкин");

        library.AddBook(first);
        library.AddBook(second);
        library.Borrow(first, reader);
        Console.WriteLine("Выдали: " + first.Title);
        Console.WriteLine("Доступна: " + first.IsAvailable);

        library.Return(first, reader);
        Console.WriteLine("Вернули: " + first.Title);
        Console.WriteLine("Доступна: " + first.IsAvailable);
    }
}

public class Book
{
    public string Title { get; }
    public string Author { get; }
    public bool IsAvailable { get; internal set; } = true;

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}

public class Reader
{
    public string Name { get; }
    public List<Book> BorrowedBooks { get; } = new List<Book>();

    public Reader(string name)
    {
        Name = name;
    }
}

public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void Borrow(Book book, Reader reader)
    {
        if (!books.Contains(book))
            throw new InvalidOperationException("Такой книги нет в библиотеке.");
        if (!book.IsAvailable)
            throw new InvalidOperationException("Книга уже выдана.");
        if (reader.BorrowedBooks.Count >= 3)
            throw new InvalidOperationException("Лимит — три книги.");

        book.IsAvailable = false;
        reader.BorrowedBooks.Add(book);
    }

    public void Return(Book book, Reader reader)
    {
        if (!reader.BorrowedBooks.Contains(book))
            throw new InvalidOperationException("Эта книга не выдана читателю.");

        reader.BorrowedBooks.Remove(book);
        book.IsAvailable = true;
    }
}
