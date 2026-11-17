using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task25_Shapes : ITask
{
    public string Title => "Фигуры и сортировка";
    public string Description => "Посчитать площади и отсортировать фигуры.";
    public string[] Requirements => new[]
    {
        "IShape с Area и Perimeter",
        "Circle, Rectangle и Triangle",
        "Не менее 5 фигур, сортировка по площади"
    };


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
        public Circle(double radius) { this.radius = radius; }
        public double Area() => Math.PI * radius * radius;
        public double Perimeter() => 2 * Math.PI * radius;
    }

    private class Rectangle : IShape
    {
        private double width;
        private double height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public double Area() => width * height;
        public double Perimeter() => 2 * (width + height);
    }

    private class Triangle : IShape
    {
        private double a;
        private double b;
        public Triangle(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public double Area() => a * b / 2;
        public double Perimeter() => a + b + Math.Sqrt(a * a + b * b);
    }
}
