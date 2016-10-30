using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Factorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other .NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus on
            //LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in call hierarchy .
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        private static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static int GetTheMagicNumber()
        {
            return IKnowIGuyWhoKnowsAGuy();
        }

        private static int IKnowIGuyWhoKnowsAGuy()
        {
            return IKnowWhoKnowsThis(10) + IKnowWhoKnowsThis(5);
        }

        private static int IKnowWhoKnowsThis(int n)
        {
            return FactorialDigitSum(n).Result;
        }


        /*public static void Main(string[] args)
        {
            Task<int> task = FactorialDigitSum(20);
            
            Console.WriteLine(task.Result);
            Console.ReadLine();
        }*/

        public static async Task<int> FactorialDigitSum(int n)
        {
            int sum = 0;

            BigInteger fac = await Task.Run(() => Factorial(n));

            while (fac > 0)
            {
                sum += (int)(fac % 10);
                fac /= 10;
            }
            return sum;
        }

        public static BigInteger Factorial(int n)
        {
            BigInteger fac = 1;
            for (uint i = 2; i <= n; i++)
                fac *= i;
            return fac;
        }
    }
}
