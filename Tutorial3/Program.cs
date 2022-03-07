using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial3
{
    internal class Program
    {
        /// <summary>
        /// Main
        /// calculating two numbers
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int first, second, result;
            string opt;
            Console.Write("Pls write Console Calculator in C# as like below:\n");
            Console.Write("---------------------------------------------------------");
            Console.Write("\n\n");
            Console.WriteLine("Type a number,then press Enter");
            first = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n\n");
            Console.WriteLine("Type another number,then press Enter ");
            second = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n\n");
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("a-Add\ns-Subtract\nm-Multiply\nd-Divide");
            Console.Write("Your option?");
            opt = Console.ReadLine();
            switch (opt)
            {
                case "a":
                    result = first + second;
                    Console.WriteLine("Your result:{0} + {1} = {2}", first, second, result);
                    break;

                case "s":
                    result = first - second;
                    Console.WriteLine("Your result:{0} - {1} = {2}", first, second, result);
                    break;

                case "m":
                    result = first * second;
                    Console.WriteLine("Your result:{0} x {1} = {2}", first, second, result);
                    break;

                case "d":
                    result = first / second;
                    Console.WriteLine("Your result:{0} ÷ {1} = {2}", first, second, result);
                    break;

                default:
                    Console.WriteLine("Please choose only from opiton");
                    break;
            }
            Console.ReadLine();
        }
    }
}