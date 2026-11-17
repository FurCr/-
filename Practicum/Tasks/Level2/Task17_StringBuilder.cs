using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task17_StringBuilder : ITask
{
    public string Title => "StringBuilder и конкатенация";
    public string Description => "Сравнить два способа создания длинной строки.";
    public string[] Requirements => new[]
    {
        "Собрать строку из 10000 чисел",
        "Замерить время с Stopwatch",
        "Проверить совпадение результата"
    };


    public void Run()
    {
        System.Diagnostics.Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();

        string first = "";
        for (int i = 1; i <= 10000; i++)
            first += i + " ";
        timer.Stop();
        double time1 = timer.Elapsed.TotalMilliseconds;

        timer.Restart();
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        for (int i = 1; i <= 10000; i++)
            builder.Append(i).Append(' ');
        string second = builder.ToString();
        timer.Stop();
        double time2 = timer.Elapsed.TotalMilliseconds;

        Console.WriteLine("Через +: " + time1.ToString("F2") + " мс");
        Console.WriteLine("Через StringBuilder: " + time2.ToString("F2") + " мс");
        Console.WriteLine("Разница: " + (time1 - time2).ToString("F2") + " мс");
        Console.WriteLine("Строки одинаковые: " + (first == second));

        // StringBuilder изменяет одну строку, а + каждый раз создаёт новую.
    }
}
