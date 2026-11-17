using Practicum.Common;

namespace Practicum.Tasks.Level3;

public class Task38_ListBenchmark : ITask
{
    public string Title => "List и LinkedList";
    public string Description => "Сравнить вставку элементов в середину списка.";
    public string[] Requirements => new[]
    {
        "100000 элементов",
        "1000 вставок в середину",
        "Stopwatch и объяснение"
    };

    public void Run()
    {
        List<int> list = new List<int>();
        LinkedList<int> linked = new LinkedList<int>();

        for (int i = 0; i < 100000; i++)
        {
            list.Add(i);
            linked.AddLast(i);
        }

        System.Diagnostics.Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < 1000; i++)
            list.Insert(list.Count / 2, i);
        timer.Stop();
        double time1 = timer.Elapsed.TotalMilliseconds;

        LinkedListNode<int> middle = linked.First!;
        for (int i = 0; i < 50000; i++)
            middle = middle.Next!;

        timer.Restart();
        for (int i = 0; i < 1000; i++)
            linked.AddBefore(middle, i);
        timer.Stop();
        double time2 = timer.Elapsed.TotalMilliseconds;

        Console.WriteLine("List: " + time1.ToString("F3") + " мс");
        Console.WriteLine("LinkedList: " + time2.ToString("F3") + " мс");

        // LinkedList быстрее вставляет по найденному узлу, но поиск середины требует прохода.
    }
}
