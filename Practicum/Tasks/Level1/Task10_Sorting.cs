using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;
using System.Diagnostics; 

namespace Practicum.Tasks.Level1;


public class Task10_Sorting : ITask
{
    public string Title => "Сортировка пузырьком + вставками";
    public string Description => "Отсортировать массив двумя алгоритмами.";
    public string[] Requirements => new[]
    {
        "Реализовать BubbleSort и InsertionSort отдельными методами",
        "Оба — без LINQ и Array.Sort",
        "Замерить время каждого через Stopwatch на массиве 10 000 элементов",
        "Вывести оба времени"
    };

    public void Run()
    {
        int size = 10000;
        Random rnd = new Random();
        int[] original = new int[size];

       
        for (int i = 0; i < size; i++) original[i] = rnd.Next(1, 100000);

       
        int[] arr1 = (int[])original.Clone();
        int[] arr2 = (int[])original.Clone();

 
        Stopwatch sw = Stopwatch.StartNew();
        BubbleSort(arr1);
        sw.Stop();
        Console.WriteLine($"BubbleSort: {sw.ElapsedMilliseconds} мс");

        
        sw.Restart(); 
        InsertionSort(arr2);
        sw.Stop();
        Console.WriteLine($"InsertionSort: {sw.ElapsedMilliseconds} мс");

      
        bool same = true;
        for (int i = 0; i < size; i++)
            if (arr1[i] != arr2[i]) { same = false; break; }

        Console.WriteLine($"Массивы отсортированы одинаково: {same}");
    }

    
    private void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (arr[j] > arr[j + 1])
                {
                  
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
    }


    private void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }
}