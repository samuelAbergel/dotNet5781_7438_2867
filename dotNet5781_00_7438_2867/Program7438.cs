using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_00_7438_2667
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome7438();
            Welcome2867();
            Console.ReadKey();
        }

        static partial void Welcome2867();
        private static void Welcome7438()
        {
            Console.WriteLine("Enter your name");
            String userName = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", userName);
        }
    }
}