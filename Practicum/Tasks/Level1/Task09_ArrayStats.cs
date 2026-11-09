using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;
public class Task09_ArrayStats : ITask
{
    public string Title => "Массивы: min/max/sum/avg";
    public string Description => "Для массива чисел найти минимум, максимум, сумму и среднее.";
    public string[] Requirements => new[]
    {
        "Заполнить массив случайными числами 1–100, размер 20",
        "Реализовать без LINQ (Min/Max/Sum/Average запрещены)",
        "Оформить 4 отдельных метода",
        "Пустой массив — обработать (вернуть ошибку или 0, но не падать)"
    };

    public void Run()
    {
        int[] arr = new int[20];
        Random rnd = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(1, 101);
        }
        Console.WriteLine("Массив: " + string.Join(", ", arr));

        // Вызываем наши методы
        Console.WriteLine($"Min: {GetMin(arr)}");
        Console.WriteLine($"Max: {GetMax(arr)}");
        Console.WriteLine($"Sum: {GetSum(arr)}");
        Console.WriteLine($"Avg: {GetAverage(arr):F2}");
    }

    private int GetMin(int[] arr)
    {
        if (arr.Length == 0) return 0; 

        int min = arr[0]; 
        foreach (var x in arr)
        {
            if (x < min) min = x;
        }
        return min;
    }


    private int GetMax(int[] arr)
    {
        if (arr.Length == 0) return 0;

        int max = arr[0];
        foreach (var x in arr)
        {
            if (x > max) max = x;
        }
        return max;
    }


    private int GetSum(int[] arr)
    {
        int sum = 0;
        foreach (var x in arr)
            sum += x;
        return sum;
    }

 
    private double GetAverage(int[] arr)
    {
        if (arr.Length == 0) return 0;
        return (double)GetSum(arr) / arr.Length;
    }
}
