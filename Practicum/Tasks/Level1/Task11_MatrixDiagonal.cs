using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;


public class Task11_MatrixDiagonal : ITask
{
    public string Title => "Диагональ матрицы N×N";
    public string Description => "Найти сумму элементов главной диагонали матрицы N×N.";
    public string[] Requirements => new[]
    {
        "Размер N вводится пользователем (минимум 2)",
        "Матрица заполняется случайными числами",
        "Сумма считается без LINQ, в одном цикле for",
        "Вывести саму матрицу и сумму"
    };

    public void Run()
    {
        Console.Write("Введите размер матрицы N (минимум 2): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 2)
        {
            Console.WriteLine("Ошибка: N должно быть >= 2.");
            return;
        }

       
        int[,] matrix = new int[n, n];
        Random rnd = new Random();

    
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                matrix[i, j] = rnd.Next(1, 10);

        Console.WriteLine("Матрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
               
                Console.Write($"{matrix[i, j],4}");
            }
            Console.WriteLine();
        }

        int sum = 0;
      
        for (int i = 0; i < n; i++)
        {
            sum += matrix[i, i];
        }
        Console.WriteLine($"Сумма главной диагонали: {sum}");
    }
}