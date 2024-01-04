using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Factorial(int number)
        {
            long fact = 1;
            for (int i = 1; i <= number; i++)
            {
                fact *= i;
            }

            Console.WriteLine($"Факториал числа {number} равен {fact}");
        }

        static void Main(string[] args)
        {
            int num;
            string path1 = $"..\\Debug\\1.txt";
            string path2 = $"..\\Debug\\2.txt";
            string path3 = $"..\\Debug\\3.txt";

            do
            {
                Console.Write("Введите номер задания: ");
                num = Convert.ToInt32(Console.ReadLine());

                switch (num)
                {
                    case 1: 
                        Console.Write("Введите текст: ");
                        string text = Console.ReadLine();
                        int choice;

                        do
                        {
                            Console.WriteLine("\n0 - количество предложений: ");
                            Console.WriteLine("1 - количество символов: ");
                            Console.WriteLine("2 - количество слов: ");
                            Console.WriteLine("3 - количество вопросительных предложений: ");
                            Console.WriteLine("4 - количество восклицательных предложений: ");
                            Console.WriteLine("5 - выход: ");
                            Console.Write("\nВведите номер задачи: ");
                            choice = Convert.ToInt32(Console.ReadLine());

                            if (choice == 0)
                            {
                                Task.Run(() =>
                                {
                                    Console.Write("Записать информацию в файл или вывести на консоль (1, 0)? ");
                                    choice = Convert.ToInt32(Console.ReadLine());
                                    int count = 0;

                                    for (int i = 0; i < text.Length; i++)
                                    {
                                        if (text.ToCharArray()[i] == '.')
                                        {
                                            count++;
                                        }
                                    }

                                    if (choice == 1)
                                    {
                                        using (StreamWriter writer = new StreamWriter(path1, true))
                                        {
                                            string line = $"Количество предложений: {count}";
                                            writer.WriteLine(line);
                                        }
                                    }
                                    else if (choice == 0)
                                    {
                                        Console.WriteLine($"Количество предложений: {count}");
                                    }
                                }).Wait();
                            }
                            if (choice == 1)
                            {
                                Task.Run(() =>
                                {
                                    Console.Write("Записать информацию в файл или вывести на консоль (1, 0)? ");
                                    choice = Convert.ToInt32(Console.ReadLine());

                                    if (choice == 1)
                                    {
                                        using (StreamWriter writer = new StreamWriter(path1, true))
                                        {
                                            string line = $"Количество символов: {text.Length}";
                                            writer.WriteLine(line);
                                        }
                                    }
                                    else if (choice == 0)
                                    {
                                        Console.WriteLine($"Количество символов: {text.Length}");
                                    }
                                }).Wait();
                            }
                            if (choice == 2)
                            {
                                Task.Run(() =>
                                {
                                    Console.Write("Записать информацию в файл или вывести на консоль (1, 0)? ");
                                    choice = Convert.ToInt32(Console.ReadLine());

                                    string[] words = text.Split(' ');

                                    if (choice == 1)
                                    {
                                        using (StreamWriter writer = new StreamWriter(path1, true))
                                        {
                                            string line = $"Количество слов: {words.Length}";
                                            writer.WriteLine(line);
                                        }
                                    }
                                    else if (choice == 0)
                                    {
                                        Console.WriteLine($"Количество слов: {words.Length}");
                                    }
                                }).Wait();
                            }
                            if (choice == 3)
                            {
                                Task.Run(() =>
                                {
                                    Console.Write("Записать информацию в файл или вывести на консоль (1, 0)? ");
                                    choice = Convert.ToInt32(Console.ReadLine());
                                    int count = 0;

                                    for (int i = 0; i < text.Length; i++)
                                    {
                                        if (text.ToCharArray()[i] == '?')
                                        {
                                            count++;
                                        }
                                    }

                                    if (choice == 1)
                                    {
                                        using (StreamWriter writer = new StreamWriter(path1, true))
                                        {
                                            string line = $"Количество вопросительных предложений: {count}";
                                            writer.WriteLine(line);
                                        }
                                    }
                                    else if (choice == 0)
                                    {
                                        Console.WriteLine($"Количество вопросительных предложений: {count}");
                                    }
                                }).Wait();
                            }
                            if (choice == 4)
                            {
                                Task.Run(() =>
                                {
                                    Console.Write("Записать информацию в файл или вывести на консоль (1, 0)? ");
                                    choice = Convert.ToInt32(Console.ReadLine());
                                    int count = 0;

                                    for (int i = 0; i < text.Length; i++)
                                    {
                                        if (text.ToCharArray()[i] == '!')
                                        {
                                            count++;
                                        }
                                    }

                                    if (choice == 1)
                                    {
                                        using (StreamWriter writer = new StreamWriter(path1, true))
                                        {
                                            string line = $"Количество восклицательных предложений: {count}";
                                            writer.WriteLine(line);
                                        }
                                    }
                                    else if (choice == 0)
                                    {
                                        Console.WriteLine($"Количество восклицательных предложений: {count}");
                                    }
                                }).Wait();
                            }
                        }
                        while (choice >= 0 && choice < 5);

                        Console.WriteLine();
                        break;

                    case 2: 
                        List<int> numbers = new List<int>() { 1, 1, 3, 8, 7, 4 };

                        Task task1 = new Task(() =>
                        {
                            numbers = numbers.Distinct().ToList();
                        });

                        Task task2 = task1.ContinueWith(o =>
                        {
                            numbers = numbers.OrderBy(x => x).ToList();
                        });

                        Task task3 = task2.ContinueWith(o =>
                        {
                            numbers.BinarySearch(4);
                        });

                        task1.Start();
                        task2.Wait();
                        task3.Wait();

                        Console.WriteLine($"Task1Id: {task1.Id} отработал\n");
                        break;

                    case 3: 
                        Console.Write("Введите число: ");
                        int number = Convert.ToInt32(Console.ReadLine());

                        Parallel.Invoke(
                            () =>
                            {
                                Factorial(number);
                            },
                            () =>
                            {
                                Console.WriteLine($"Количество цифр в числе равно {number.ToString().Length}");
                            },
                            () =>
                            {
                                List<int> digits = number.ToString().Select(ch => int.Parse(ch.ToString())).ToList();
                                Console.WriteLine($"Сумма чисел массива равна {digits.Sum()}");
                            }
                        );

                        Console.WriteLine();
                        break;

                    case 4: 
                        List<int> numb = new List<int>();
                        using (StreamReader stream = new StreamReader(path2))
                        {
                            string line = stream.ReadToEnd();
                            numb = line.Split(' ').Select(ch => int.Parse(ch.ToString())).ToList();
                        }
                        ParallelLoopResult result = Parallel.ForEach(numb, Factorial);

                        Console.WriteLine();
                        break;

                    case 5: 
                        List<int> numb2 = new List<int>();
                        using (StreamReader stream = new StreamReader(path3))
                        {
                            string line = stream.ReadToEnd();
                            numb2 = line.Split(' ').Select(ch => int.Parse(ch.ToString())).ToList();
                        }

                        Task task = new Task(() =>
                        {
                            var longestSequenceLength = numb2.AsParallel().Aggregate(
                                new { Max = 0, Current = 0, Previous = numb2.Min() },
                                (a, x) => x > a.Previous ?
                                new { Max = a.Max > a.Current + 1 ? a.Max : a.Current + 1, Current = a.Current + 1, Previous = x } :
                                new { Max = a.Max, Current = 0, Previous = numb2.Min() })
                            .Max + 1;

                            Console.WriteLine($"Длина наибольшей возрастающей последовательности: {longestSequenceLength}");
                        });

                        task.Start();
                        task.Wait();
                        Console.WriteLine();
                        break;

                    case 6: 
                        List<int> numb3 = new List<int>();
                        using (StreamReader stream = new StreamReader(path3))
                        {
                            string line = stream.ReadToEnd();
                            numb3 = line.Split(' ').Select(ch => int.Parse(ch.ToString())).ToList();
                        }

                        Task tassk = new Task(() =>
                        {
                            var longestSequenceLength = numb3.AsParallel().Aggregate(
                                new { Max = 0, Current = 0 },
                                (a, x) => x > 0 ?
                                new { Max = a.Max > a.Current + 1 ? a.Max : a.Current + 1, Current = a.Current + 1 } : 
                                new { Max = a.Max, Current = 0 })
                            .Max;

                            Console.WriteLine($"Длина наибольшей последовательности +чисел: {longestSequenceLength}");
                        });

                        tassk.Start();
                        tassk.Wait();
                        Console.WriteLine();
                        break;
                }
            }
            while (num > 0 && num < 8);
            Console.WriteLine();
        }
    }
}