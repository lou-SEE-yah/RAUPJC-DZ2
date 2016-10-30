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

        public static University[] GetAllCroatianUniversities()
        {
            University[] list = new University[5];
            string[] listaImenaFakulteta = new string[5] { "FER", "TVZ", "FSB", "PMF", "RGN" };

            Student[] studenti = new Student[20];
            string[] listaImenaStudenata = new string[20] { "Ana", "Luka", "Marko", "Ivan", "Lucija", "Ivana", "Matej", "Juraj", "Karlo", "Kristijan", "David", "Josip", "Sara", "Eva", "Iva", "Igor", "Petar", "Tin", "Vito", "Mario" };
            string[] listaJMBAG = new string[20] { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19" };

            for (int i = 0; i < 20; i++)
            {
                Student student = new Student(listaImenaStudenata[i], listaJMBAG[i]);
                if (student.Name.EndsWith("a"))
                {
                    student.Gender = Gender.Female;
                }
                else
                {
                    student.Gender = Gender.Male;
                }
                studenti[i] = student;
            }

            Student s = new Student("Eustahije", "20");
            s.Gender = Gender.Male;
            for (int i = 0; i < 5; i++)
            {
                University faks = new University();
                faks.Name = listaImenaFakulteta[i];
                faks.Students = new Student[5];
                Array.Copy(studenti, i*4, faks.Students, 0, 4);
                faks.Students[4] = s;
                list[i] = faks;
            }


            return list;
        }


        public static void Main(string[] args)
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

            Example1();
            Example2();

            University[] universities = GetAllCroatianUniversities();
            //Student[] allCroatianStudents = universities.SelectMany(s => s.Students);
            /*Student[] croatianStudentsOnMultipleUniversities = // ...
            Student[] studentsOnMaleOnlyUniversities = // ...*/
        }
    }
}
