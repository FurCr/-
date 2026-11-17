using Practicum.Common;

namespace Practicum.Tasks.Level3;

public class Task40_AsyncDownload : ITask
{
    public string Title => "async/await и ошибки";
    public string Description => "Имитировать скачивание с обработкой исключения.";
    public string[] Requirements => new[]
    {
        "DownloadAsync с Task.Delay(1000)",
        "Ошибка при пустом URL",
        "Успешный и ошибочный вызов"
    };

    public void Run()
    {
        RunAsync().GetAwaiter().GetResult();
    }

    private static async Task RunAsync()
    {
        foreach (string address in new[] { "https://example.com", "" })
        {
            try
            {
                string result = await DownloadAsync(address);
                Console.WriteLine(result);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }

    private static async Task<string> DownloadAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("Адрес не указан.");

        await Task.Delay(1000);
        return "Скачивание завершено: " + url;
    }
}
