using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static int Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(3000);
            Console.WriteLine($"Факториал равен {result}");
            return result;
        }
        // определение асинхронного метода
        static async Task<int> FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            var task = Task.Run(Factorial);
            await task;                            // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");  // выполняется синхронно
            return task.Result;
        }

        static void Main(string[] args)
        {
            Task<int> calculation = FactorialAsync();   // вызов асинхронного метода

            Console.WriteLine("Введите число: ");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Квадрат числа равен {n * n}");
            Console.Write("Метод Main, результат вычисления FactorialAsync() равен " + calculation.Result);
            Console.Read();
        }
    }
}
