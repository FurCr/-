using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task19_StackQueue : ITask
{
    public string Title => "Стек и очередь";
    public string Description => "Сделать стек и очередь на массивах.";
    public string[] Requirements => new[]
    {
        "Push, Pop, Peek и Enqueue, Dequeue, Peek",
        "Count и IsEmpty",
        "Увеличение массива и ошибка пустой коллекции"
    };


    public void Run()
    {
        MyStack<int> stack = new MyStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        Console.WriteLine("Вершина стека: " + stack.Peek());
        Console.WriteLine("Извлекли: " + stack.Pop());
        stack.Push(40);
        stack.Push(50);
        Console.WriteLine("В стеке: " + stack.Count);
        while (!stack.IsEmpty)
            Console.WriteLine("Pop: " + stack.Pop());
        try { stack.Pop(); }
        catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }

        Console.WriteLine();

        MyQueue<int> queue = new MyQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Console.WriteLine("Первый в очереди: " + queue.Peek());
        Console.WriteLine("Забрали: " + queue.Dequeue());
        queue.Enqueue(4);
        queue.Enqueue(5);
        Console.WriteLine("В очереди: " + queue.Count);
        while (!queue.IsEmpty)
            Console.WriteLine("Dequeue: " + queue.Dequeue());
        try { queue.Dequeue(); }
        catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
    }

    private class MyStack<T>
    {
        private T[] items = new T[2];
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void Push(T item)
        {
            if (Count == items.Length)
                Array.Resize(ref items, items.Length * 2);
            items[Count] = item;
            Count++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст.");
            Count--;
            T item = items[Count];
            items[Count] = default!;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст.");
            return items[Count - 1];
        }
    }

    private class MyQueue<T>
    {
        private T[] items = new T[2];
        private int start;
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void Enqueue(T item)
        {
            if (Count == items.Length)
            {
                T[] bigger = new T[items.Length * 2];
                for (int i = 0; i < Count; i++)
                    bigger[i] = items[(start + i) % items.Length];
                items = bigger;
                start = 0;
            }
            items[(start + Count) % items.Length] = item;
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста.");
            T result = items[start];
            items[start] = default!;
            start = (start + 1) % items.Length;
            Count--;
            return result;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста.");
            return items[start];
        }
    }
}
