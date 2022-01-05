using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ЗАДАНИЕ 23. АСИНХРОННОЕ ПРОГРАММИРОВАНИЕ";
            long x = 0;
            do
            {
                try
                {
                    Console.Write("Введите число N: ");
                    long n = Convert.ToUInt32(Console.ReadLine());
                    x = FactAsync(n).Result;

                    if (x == 0) throw new Exception();
                    Console.WriteLine("\nФакториал числа существует!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Введено недопустимое число, попробуйте еще раз!\n");
                }
            }
            while (x == 0);

            Console.ReadLine();
        }
        static long Factorial(long n)
        {
            long fact = 1;
            for (long i = 1; i <= n; i++)
            {
                fact *= i;
            }
            Console.WriteLine($"Факториал числа {n} равен: {fact}");
            return fact;
        }
        static async Task<long> FactAsync(long n)
        {
            long result = await Task.Run(() => Factorial(n));
            return result;
        }
    }
}

//1.Разработать асинхронный метод для вычисления факториала числа. В методе Main выполнить проверку работы метода.
