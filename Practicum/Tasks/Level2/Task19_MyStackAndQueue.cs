using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 19. Свой стек/очередь на массиве.</summary>
public class Task19_MyStackAndQueue : ITask
{
    public string Title => "Свой стек/очередь на массиве";
    public string Description => "Реализовать MyStack<T> и MyQueue<T> на массиве.";
    public string[] Requirements => new[]
    {
        "Стек: Push, Pop, Peek, Count, IsEmpty",
        "Очередь: Enqueue, Dequeue, Peek, Count, IsEmpty",
        "При переполнении — расширять внутренний массив (удвоение)",
        "Pop/Dequeue на пустой коллекции — бросать InvalidOperationException"
    };

    public void Run()
    {
        Console.WriteLine("--- Тест MyStack ---");
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine($"Peek: {stack.Peek()}, Count: {stack.Count}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Pop: {stack.Pop()}");

        Console.WriteLine("\n--- Тест MyQueue ---");
        var queue = new MyQueue<string>();
        queue.Enqueue("A");
        queue.Enqueue("B");
        Console.WriteLine($"Peek: {queue.Peek()}, Count: {queue.Count}");
        Console.WriteLine($"Dequeue: {queue.Dequeue()}");

        Console.WriteLine("\n--- Проверка исключений на пустых ---");
        var emptyStack = new MyStack<int>();
        try { emptyStack.Pop(); }
        catch (InvalidOperationException ex) { Console.WriteLine($"Ошибка стека: {ex.Message}"); }
    }
}

public class MyStack<T>
{
    private T[] _items = new T[4];
    public int Count { get; private set; }
    public bool IsEmpty => Count == 0;

    public void Push(T item)
    {
        if (Count == _items.Length) Array.Resize(ref _items, _items.Length * 2);
        _items[Count++] = item;
    }

    public T Pop()
    {
        if (IsEmpty) throw new InvalidOperationException("Стек пуст");
        return _items[--Count];
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Стек пуст");
        return _items[Count - 1];
    }
}

public class MyQueue<T>
{
    private T[] _items = new T[4];
    private int _head = 0;
    private int _tail = 0;
    public int Count => _tail - _head;
    public bool IsEmpty => Count == 0;

    public void Enqueue(T item)
    {
        if (_tail == _items.Length) Array.Resize(ref _items, _items.Length * 2);
        _items[_tail++] = item;
    }

    public T Dequeue()
    {
        if (IsEmpty) throw new InvalidOperationException("Очередь пуста");
        T item = _items[_head];
        _items[_head++] = default!;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Очередь пуста");
        return _items[_head];
    }
}