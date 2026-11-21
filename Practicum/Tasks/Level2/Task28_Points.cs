using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №28.</summary>
public class Task28_Points : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Сравнение точек";
    /// <summary>Описание задания.</summary>
    public string Description => "Проверить равенство точек и работу HashSet.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "IEquatable<Point> и Equals(object)",
        "GetHashCode для координат",
        "Проверить дубликаты в HashSet"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Point first = new Point(2, 3);
        Point second = new Point(2, 3);
        Point third = new Point(5, 1);

        Console.WriteLine("Первые две точки равны: " + first.Equals(second));

        HashSet<Point> points = new HashSet<Point>();
        points.Add(first);
        points.Add(second);
        points.Add(third);

        Console.WriteLine("Уникальных точек: " + points.Count);
    }

    private class Point : IEquatable<Point>
    {
        /// <summary>Координата X.</summary>
        public int X { get; }
        /// <summary>Координата Y.</summary>
        public int Y { get; }

        /// <summary>Создаёт точку.</summary>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>Сравнивает точки по координатам.</summary>
        public bool Equals(Point? other)
        {
            return other != null && X == other.X && Y == other.Y;
        }

        /// <summary>Проверяет равенство с другим объектом.</summary>
        public override bool Equals(object? obj)
        {
            return obj is Point other && Equals(other);
        }

        /// <summary>Вычисляет хеш по координатам.</summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
