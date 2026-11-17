using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №45.</summary>
public class Task45_Library : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Библиотека";
    /// <summary>Описание задания.</summary>
    public string Description => "Выдача и возврат книг.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Book, Reader и Library",
        "Не больше трёх книг на читателя",
        "Исключения и юнит-тесты"
    };

    /// <summary>Запускает задание.</summary>
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

/// <summary>Выполняет действие.</summary>
public class Book
{
    /// <summary>Название задания.</summary>
    public string Title { get; }
    /// <summary>Выполняет действие.</summary>
    public string Author { get; }
    /// <summary>Доступна ли книга.</summary>
    public bool IsAvailable { get; internal set; } = true;

    /// <summary>Выполняет действие.</summary>
    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}

/// <summary>Выполняет действие.</summary>
public class Reader
{
    /// <summary>Имя.</summary>
    public string Name { get; }
    /// <summary>Выданные книги.</summary>
    public List<Book> BorrowedBooks { get; } = new List<Book>();

    /// <summary>Выполняет действие.</summary>
    public Reader(string name)
    {
        Name = name;
    }
}

/// <summary>Выполняет действие.</summary>
public class Library
{
    private List<Book> books = new List<Book>();

    /// <summary>Выполняет действие.</summary>
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    /// <summary>Выдаёт книгу.</summary>
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

    /// <summary>Возвращает книгу.</summary>
    public void Return(Book book, Reader reader)
    {
        if (!reader.BorrowedBooks.Contains(book))
            throw new InvalidOperationException("Эта книга не выдана читателю.");

        reader.BorrowedBooks.Remove(book);
        book.IsAvailable = true;
    }
}
