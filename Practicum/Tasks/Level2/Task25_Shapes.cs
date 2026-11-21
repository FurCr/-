using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №25.</summary>
public class Task25_Shapes : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Фигуры и сортировка";
    /// <summary>Описание задания.</summary>
    public string Description => "Посчитать площади и отсортировать фигуры.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "IShape с Area и Perimeter",
        "Circle, Rectangle и Triangle",
        "Не менее 5 фигур, сортировка по площади"
    };


    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        List<IShape> shapes = new List<IShape>
        {
            new Circle(3), new Rectangle(2, 5), new Triangle(3, 4),
            new Circle(1), new Rectangle(4, 6), new Triangle(5, 12)
        };

        Console.WriteLine("До сортировки:");
        Show(shapes);

        shapes.Sort((a, b) => a.Area().CompareTo(b.Area()));

        Console.WriteLine("После сортировки:");
        Show(shapes);
    }

    private static void Show(List<IShape> shapes)
    {
        foreach (IShape shape in shapes)
            Console.WriteLine(shape.GetType().Name + ": площадь " + shape.Area().ToString("F2") +
                              ", периметр " + shape.Perimeter().ToString("F2"));
    }

    private interface IShape
    {
        double Area();
        double Perimeter();
    }

    private class Circle : IShape
    {
        private double radius;
        /// <summary>Создаёт круг.</summary>
        public Circle(double radius) { this.radius = radius; }
        /// <summary>Вычисляет площадь.</summary>
        public double Area() => Math.PI * radius * radius;
        /// <summary>Вычисляет периметр.</summary>
        public double Perimeter() => 2 * Math.PI * radius;
    }

    private class Rectangle : IShape
    {
        private double width;
        private double height;
        /// <summary>Создаёт прямоугольник.</summary>
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        /// <summary>Вычисляет площадь.</summary>
        public double Area() => width * height;
        /// <summary>Вычисляет периметр.</summary>
        public double Perimeter() => 2 * (width + height);
    }

    private class Triangle : IShape
    {
        private double a;
        private double b;
        /// <summary>Создаёт треугольник.</summary>
        public Triangle(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        /// <summary>Вычисляет площадь.</summary>
        public double Area() => a * b / 2;
        /// <summary>Вычисляет периметр.</summary>
        public double Perimeter() => a + b + Math.Sqrt(a * a + b * b);
    }
}
