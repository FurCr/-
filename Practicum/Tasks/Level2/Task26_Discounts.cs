using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №26.</summary>
public class Task26_Discounts : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Стратегия: скидки";
    /// <summary>Описание задания.</summary>
    public string Description => "Посчитать цену с разными скидками.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "IDiscountStrategy и метод Apply",
        "NoDiscount, VipDiscount, PromoDiscount",
        "PriceCalculator принимает стратегию"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        decimal price = 1000m;
        Console.WriteLine("Начальная цена: " + price);

        IDiscountStrategy[] discounts =
        {
            new NoDiscount(), new VipDiscount(), new PromoDiscount()
        };

        foreach (IDiscountStrategy discount in discounts)
        {
            PriceCalculator calculator = new PriceCalculator(discount);
            Console.WriteLine(discount.GetType().Name + ": " + calculator.Calculate(price));
        }
    }

    private interface IDiscountStrategy
    {
        decimal Apply(decimal price);
    }

    private class NoDiscount : IDiscountStrategy
    {
        /// <summary>Возвращает цену с учётом выбранной скидки.</summary>
        public decimal Apply(decimal price) => price;
    }

    private class VipDiscount : IDiscountStrategy
    {
        /// <summary>Возвращает цену с учётом выбранной скидки.</summary>
        public decimal Apply(decimal price) => price * 0.90m;
    }

    private class PromoDiscount : IDiscountStrategy
    {
        /// <summary>Возвращает цену с учётом выбранной скидки.</summary>
        public decimal Apply(decimal price) => price * 0.80m;
    }

    private class PriceCalculator
    {
        private IDiscountStrategy strategy;

        /// <summary>Сохраняет стратегию скидки.</summary>
        public PriceCalculator(IDiscountStrategy strategy)
        {
            this.strategy = strategy;
        }

        /// <summary>Рассчитывает итоговую цену.</summary>
        public decimal Calculate(decimal price) => strategy.Apply(price);
    }
}
