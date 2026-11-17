using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task34_WordGroups : ITask
{
    public string Title => "LINQ: группировка слов";
    public string Description => "Сгруппировать слова по первой букве.";
    public string[] Requirements => new[]
    {
        "Не менее 10 слов",
        "GroupBy по первой букве",
        "Сортировка групп и слов"
    };

    public void Run()
    {
        List<string> words = new List<string>
        {
            "арбуз", "банан", "апельсин", "груша", "виноград", "ананас",
            "вишня", "дыня", "брусника", "ежевика", "гранат", "дыня"
        };

        var groups = words.GroupBy(word => word[0]).OrderBy(group => group.Key);
        foreach (var group in groups)
        {
            var sortedWords = group.OrderBy(word => word);
            Console.WriteLine(group.Key + ": " + string.Join(", ", sortedWords));
        }
    }
}
