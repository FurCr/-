using Practicum.Tasks.Level3;
using Xunit;

namespace Practicum.Tests;

public class LibraryTests
{
    [Fact]
    public void Borrow_MarksBookUnavailable()
    {
        Library library = new Library();
        Book book = new Book("Книга", "Автор");
        Reader reader = new Reader("Ира");
        library.AddBook(book);

        library.Borrow(book, reader);

        Assert.False(book.IsAvailable);
        Assert.Single(reader.BorrowedBooks);
    }

    [Fact]
    public void Return_MakesBookAvailable()
    {
        Library library = new Library();
        Book book = new Book("Книга", "Автор");
        Reader reader = new Reader("Ира");
        library.AddBook(book);
        library.Borrow(book, reader);

        library.Return(book, reader);

        Assert.True(book.IsAvailable);
        Assert.Empty(reader.BorrowedBooks);
    }

    [Fact]
    public void Borrow_SameBookTwiceThrows()
    {
        Library library = new Library();
        Book book = new Book("Книга", "Автор");
        Reader reader = new Reader("Ира");
        library.AddBook(book);
        library.Borrow(book, reader);

        Assert.Throws<InvalidOperationException>(() => library.Borrow(book, reader));
    }

    [Fact]
    public void Borrow_FourthBookThrows()
    {
        Library library = new Library();
        Reader reader = new Reader("Ира");
        Book[] books =
        {
            new Book("Первая", "Автор"),
            new Book("Вторая", "Автор"),
            new Book("Третья", "Автор"),
            new Book("Четвёртая", "Автор")
        };
        foreach (Book book in books)
            library.AddBook(book);

        for (int i = 0; i < 3; i++)
            library.Borrow(books[i], reader);

        Assert.Throws<InvalidOperationException>(() => library.Borrow(books[3], reader));
        Assert.Equal(3, reader.BorrowedBooks.Count);
    }

    [Fact]
    public void Return_UnborrowedBookThrows()
    {
        Library library = new Library();
        Book book = new Book("Книга", "Автор");
        Reader reader = new Reader("Ира");
        library.AddBook(book);

        Assert.Throws<InvalidOperationException>(() => library.Return(book, reader));
    }

    [Fact]
    public void Borrow_UnknownBookThrows()
    {
        Library library = new Library();
        Book book = new Book("Другая книга", "Автор");
        Reader reader = new Reader("Ира");

        Assert.Throws<InvalidOperationException>(() => library.Borrow(book, reader));
    }
}
