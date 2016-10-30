using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQIzrazi
{
    class Program
    {
        public static void Example1()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            
            bool anyIvanExists = list.Any(s => s == ivan);
            Console.WriteLine(anyIvanExists);
            Console.ReadLine();
        }

        public static void Example2()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 "),
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            
            var distinctStudents = list.Distinct().Count();
            Console.WriteLine(distinctStudents);
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            int[] integers = new[] { 1, 2, 2, 2, 3, 3, 4, 5 };
            string[] strings =
            integers.GroupBy(s => s)
                .Select(s => "Broj " + s.Key.ToString() + " ponavlja se " + s.Count().ToString() + " puta")
                .ToArray();
            Console.WriteLine(strings[0]);
            Console.WriteLine(strings[1]);
            Console.WriteLine(strings[2]);
            Console.WriteLine(strings[3]);
            Console.WriteLine(strings[4]);
            Console.ReadLine();
            Example1();
            Example2();
        }
    }
}
