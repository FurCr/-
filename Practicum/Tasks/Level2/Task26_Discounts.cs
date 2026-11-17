using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task26_Discounts : ITask
{
    public string Title => "Стратегия: скидки";
    public string Description => "Посчитать цену с разными скидками.";
    public string[] Requirements => new[]
    {
        "IDiscountStrategy и метод Apply",
        "NoDiscount, VipDiscount, PromoDiscount",
        "PriceCalculator принимает стратегию"
    };

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
        public decimal Apply(decimal price) => price;
    }

    private class VipDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price * 0.90m;
    }

    private class PromoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price * 0.80m;
    }

    private class PriceCalculator
    {
        private IDiscountStrategy strategy;

        public PriceCalculator(IDiscountStrategy strategy)
        {
            this.strategy = strategy;
        }

        public decimal Calculate(decimal price) => strategy.Apply(price);
    }
}
