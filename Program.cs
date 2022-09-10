﻿using System;

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

        static void Main(string[] args) {
            //Problem1();
            //Problem2();
            //Problem3();
            //Problem4();
            Problem5();
        }
    }
}
