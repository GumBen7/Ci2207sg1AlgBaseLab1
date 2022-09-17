using System;
using System.Collections.Generic;
using System.Linq;

namespace Ci2207sg1AlgBaseLab1 { 
    class Program {
        static void Problem1() {
            int a = 3;
            int b = 7;
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
            Console.WriteLine(a + " " + b);
        }

        static void Problem2() {
            double c = Math.Pow(Math.Max(Math.Round(Math.Abs(-Math.Sqrt(3457))), 48), 1);
            Console.WriteLine(c);
        }

        static void Problem3() {
            string s = Console.ReadLine();
            int lenght = s.Length;
            int number = Int32.Parse(s);
            bool isPalindrom = true;
            int k = 10;
            int j = Convert.ToInt32(Math.Pow(10, lenght-1));
            for (int i = 0; i < lenght / 2; i++) {
                if ((number % k) / (k / 10) != (number / j) % (10)) {
                    isPalindrom = false;
                    break;
                  }
                k *= 10;
                j /= 10;
            }
            if (isPalindrom) {
                Console.WriteLine("Yes");
            } else {
                Console.WriteLine("No");
            }
        }

        static double MeterToCentimeter(double x) {
            return 100 * x;
        }
        
        static void Problem4() {
            const double DiameterInCm = 80; 
            const double CircumferenceInCm = DiameterInCm * Math.PI;
            const double EstimatedFullCircles = 2000;
            double DistanceInM = Double.Parse(Console.ReadLine());
            Console.WriteLine(Math.Floor(MeterToCentimeter(DistanceInM)/(CircumferenceInCm)/EstimatedFullCircles));
        }

        static bool isUnderParabola(double x, double y) {
            return y < x*x;
        }

        static bool isRightToTheLineFromZero(double x, double y) {
            if (x < 0) {
                return y > 2 - x;
            }
            if (x > 0) {
                return y < 2 - x;
            }
            return false;
        }

        static void Problem5() {
            double x = Double.Parse(Console.ReadLine());
            double y = Double.Parse(Console.ReadLine());
            if (isUnderParabola(x, y) && isRightToTheLineFromZero(x, y)) {
                Console.WriteLine("Принадлежит");
            } else {
                Console.WriteLine("Не принадлежит");
            }
        }

        private static Random rand = new Random();

        static List<int> Shuffle(List<int> l) {
            int n = l.Count;  
            while (n > 1) {  
                n--;  
                int k = rand.Next(n + 1); 
                int value = l[k];  
                l[k] = l[n];  
                l[n] = value;  
            } 
            return l;
        }

        static int[] Prep() {
            List<int> l = new List<int>();
            for (int i = 0; i < 100; i++) {
                int r = rand.Next(100);
                l.Add(r);
                l.Add(r);
            }
            int r2;
            do {
                r2 = rand.Next(100);
            } while (l.Contains(r2));
            l.Add(r2);
            l = Shuffle(l);
            return l.ToArray();
        }
        static void Problem6() {            
            int[] a = Prep();
            bool[] b = new bool[1000];
            foreach (int i in a) {
                if (b[i]) {
                    b[i] = false;
                } else {
                    b[i] = true;
                }
            }            
            Console.WriteLine(Array.IndexOf(b, true));
            int sum = 0;
            foreach(int i in a) {
                sum += i;
            }
            Console.WriteLine(sum + " " + sum / 2);
        }

        static List<int> CreateList(int n) {
            List<int> l = new List<int>();
            for (int i = 2; i < n; i++) {
                l.Add(i);
            }
            return l;
        }

        static void Problem7() {
            int n = Int32.Parse(Console.ReadLine());
            List<int> l = CreateList(n + 1);
            List<int> l2 = new List<int>();
            int p = 2;
            while (p != l.Last()) {
                int s = p;
                while (s < n) {
                    l.Remove(s);
                    s += p;
                }
                l2.Add(p);
                p = l.First();
            }
            l2.ForEach(i => Console.Write(i + "\t"));
        }

        static int FindFalseAfterP(bool[] a, int p) {
            for(int i = p + 1; i < a.Length; i++) {
                if (!a[i]) {
                    return i;
                }
            } 
            return a.Length;
        }

        static void Problem8() {
            int n = Int32.Parse(Console.ReadLine());
            bool[] a = new bool[n + 1];
            a[0] = true;
            a[1] = true;
            int p = 2;
            while (p < n) {
                int s = p + p;
                while (s < n) {
                    a[s] = true; 
                    s += p;                   
                }
                p = FindFalseAfterP(a, p);             
            }
            for(int i = 0; i < n; ++i) {
                if (!a[i]) {
                    Console.Write(i + "\t");
                }
            }
        }

        static void Main(string[] args) {
            //Problem1();
            //Problem2();
            //Problem3();
            //Problem4();
            //Problem5();
            //Problem6();
            //Problem7();
            Problem8();
        }
    }
}
