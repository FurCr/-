using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №24.</summary>
public class Task24_Animals : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Животные: наследование";
    /// <summary>Описание задания.</summary>
    public string Description => "Создать классы животных и показать полиморфизм.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Абстрактный Animal и ToString",
        "Dog, Cat и Bird с MakeSound",
        "List<Animal> и метод Bird.Fly"
    };


    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Каждое животное издаёт свой звук.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Все животные имеют метод MakeSound, но звуки разные.";

    /// <summary>Запускает задание.</summary>
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
        /// <summary>Имя.</summary>
        public string Name { get; }

        protected Animal(string name)
        {
            Name = name;
        }

        /// <summary>Издаёт звук.</summary>
        public abstract void MakeSound();

        /// <summary>Выполняет действие.</summary>
        public override string ToString()
        {
            return GetType().Name + ": " + Name;
        }
    }

    private class Dog : Animal
    {
        /// <summary>Выполняет действие.</summary>
        public Dog(string name) : base(name) { }
        /// <summary>Издаёт звук.</summary>
        public override void MakeSound() => Console.WriteLine("Гав!");
    }

    private class Cat : Animal
    {
        /// <summary>Выполняет действие.</summary>
        public Cat(string name) : base(name) { }
        /// <summary>Издаёт звук.</summary>
        public override void MakeSound() => Console.WriteLine("Мяу!");
    }

    private class Bird : Animal
    {
        /// <summary>Выполняет действие.</summary>
        public Bird(string name) : base(name) { }
        /// <summary>Издаёт звук.</summary>
        public override void MakeSound() => Console.WriteLine("Чик-чирик!");
        /// <summary>Имя.</summary>
        public void Fly() => Console.WriteLine(Name + " летает.");
    }
}
