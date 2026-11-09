using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;

/// <summary>Регистрирует все задания уровня 1.</summary>
public static class Level1Registry
{
    public static ITask[] Tasks { get; } = new ITask[]
    {
        new Task01_HelloWorld(),
        new Task02_Primitives(),
        new Task03_Calculator(),
        new Task04_EvenOdd(),
        new Task05_MultiplicationTable(),
        new Task06_DigitSum(),
        new Task07_ReverseString(),
        new Task08_FizzBuzz(),
        new Task09_ArrayStats(),
        new Task10_Sorting(),
        new Task11_MatrixDiagonal(),
        new Task12_Palindrome(),
        new Task13_WordCounter(),
        new Task14_AgeCalculator()

    };
}
