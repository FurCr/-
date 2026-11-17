using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task28_Points : ITask
{
    public string Title => "Сравнение точек";
    public string Description => "Проверить равенство точек и работу HashSet.";
    public string[] Requirements => new[]
    {
        "IEquatable<Point> и Equals(object)",
        "GetHashCode для координат",
        "Проверить дубликаты в HashSet"
    };

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
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point? other)
        {
            return other != null && X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
