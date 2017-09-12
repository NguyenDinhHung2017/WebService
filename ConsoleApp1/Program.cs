using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 10;

            var fib10 = FibonanciService.CalculateFibonanci(10);

            Console.WriteLine("Fibonanci of 10 = {0}",fib10);
            Console.ReadLine();
        }
    }
}
