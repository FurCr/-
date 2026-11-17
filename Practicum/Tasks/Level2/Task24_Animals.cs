using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task24_Animals : ITask
{
    public string Title => "Животные: наследование";
    public string Description => "Создать классы животных и показать полиморфизм.";
    public string[] Requirements => new[]
    {
        "Абстрактный Animal и ToString",
        "Dog, Cat и Bird с MakeSound",
        "List<Animal> и метод Bird.Fly"
    };


    public void Run()
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog("Рекс"), new Cat("Барсик"), new Bird("Кеша")
        };

        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
            animal.MakeSound();
            if (animal is Bird bird)
                bird.Fly();
        }
    }

    private abstract class Animal
    {
        public string Name { get; }

        protected Animal(string name)
        {
            Name = name;
        }

        public abstract void MakeSound();

        public override string ToString()
        {
            return GetType().Name + ": " + Name;
        }
    }

    private class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine("Гав!");
    }

    private class Cat : Animal
    {
        public Cat(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine("Мяу!");
    }

    private class Bird : Animal
    {
        public Bird(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine("Чик-чирик!");
        public void Fly() => Console.WriteLine(Name + " летает.");
    }
}
