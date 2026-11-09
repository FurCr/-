using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 26. Паттерн «Стратегия» (скидки).</summary>
public class Task26_DiscountStrategy : ITask
{
    public string Title => "Паттерн «Стратегия» (скидки)";
    public string Description => "Реализовать калькулятор скидок через паттерн «Стратегия».";
    public string[] Requirements => new[]
    {
        "Интерфейс IDiscountStrategy с методом Apply(decimal price)",
        "Реализации: NoDiscount, VipDiscount (10%), PromoDiscount (20%)",
        "Класс PriceCalculator, принимающий стратегию в конструкторе",
        "Продемонстрировать расчёт цены с каждой стратегией"
    };

    public void Run()
    {
        decimal originalPrice = 1000m;

        var noDiscount = new PriceCalculator(new NoDiscount());
        var vip = new PriceCalculator(new VipDiscount());
        var promo = new PriceCalculator(new PromoDiscount());

        Console.WriteLine($"Базовая цена: {originalPrice}");
        Console.WriteLine($"Без скидки: {noDiscount.Calculate(originalPrice)}");
        Console.WriteLine($"VIP (10%): {vip.Calculate(originalPrice)}");
        Console.WriteLine($"Промокод (20%): {promo.Calculate(originalPrice)}");
    }
}

public interface IDiscountStrategy
{
    decimal Apply(decimal price);
}

public class NoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price;
}

public class VipDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price * 0.9m;
}

public class PromoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price * 0.8m;
}

public class PriceCalculator
{
    private readonly IDiscountStrategy _strategy;

    public PriceCalculator(IDiscountStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal Calculate(decimal price) => _strategy.Apply(price);
}