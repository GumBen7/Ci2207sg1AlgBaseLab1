using System;

namespace Ci2207sg1AlgBaseLab1 { 
    class Program {
        static void Main(string[] args) {
            int a = 3;
            int b = 7;
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
            Console.WriteLine(a + " " + b);

            double c = Math.Pow(Math.Max(Math.Round(Math.Abs(-Math.Sqrt(3457))), 48), 1);
            Console.WriteLine(c);

            string s = Console.ReadLine();
            int lenght = s.Length;
            int number = Int32.Parse(s);
            bool isPalindrom = true;
            int k = 10;
            int j = 100000;
            for (int i = 0; i < lenght / 2; i++) {
                Console.WriteLine((number % k) / (k/10) + " " + (number / j) % (10));
                if ((number % k) / (k / 10) != (number / j) % (10)) {
                    isPalindrom = false;
                    break;
                  }
                k *= 10;
                j /= 10;
            }
            if (isPalindrom) {
                Console.WriteLine("Yes");
            } else
            {
                Console.WriteLine("No");
            }
        }
    }
}
