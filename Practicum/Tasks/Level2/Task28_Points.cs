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
        /// <summary>Выполняет действие.</summary>
        public int X { get; }
        /// <summary>Выполняет действие.</summary>
        public int Y { get; }

        /// <summary>Выполняет действие.</summary>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>Выполняет действие.</summary>
        public bool Equals(Point? other)
        {
            return other != null && X == other.X && Y == other.Y;
        }

        /// <summary>Выполняет действие.</summary>
        public override bool Equals(object? obj)
        {
            return obj is Point other && Equals(other);
        }

        /// <summary>Выполняет действие.</summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
