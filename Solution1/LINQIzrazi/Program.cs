using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQIzrazi
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = new[] {1, 2, 2, 2, 3, 3, 4, 5};
            string[] strings =
            integers.GroupBy(s => s)
                .Select(s => "Broj " + s.Key.ToString() + " ponavlja se " + s.Count().ToString() + " puta")
                .ToArray();
            Console.WriteLine(strings[0]);
            Console.WriteLine(strings[1]);
            Console.WriteLine(strings[2]);
            Console.WriteLine(strings[3]);
            Console.WriteLine(strings[4]);
            Console.ReadKey();
        }
    }
}
