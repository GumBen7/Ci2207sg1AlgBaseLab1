using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        static void Problem7(List<int> l, int n) {
            int p = 2;
            int i = 1;
            while (p != l.Last()) {
                int s = p + p;
                while (s < n) {
                    l.Remove(s);
                    s += p;
                }
                ++i;
                p = l[i];
            }
            foreach(int j in l) {
                Console.Write(j + "\t");
            }
        }

        static void Problem8(int n) {
            bool[] a = new bool[n + 1];
            a[0] = true;
            a[1] = true;
            double sqrN = Math.Sqrt(n);
            for (int i = 2; i < sqrN; ++i) {
                for (int s = i*i; s < n; s += i) {
                    a[s] = true;                   
                }         
            }
            /*for(int i = 0; i < n; ++i) {
                if (!a[i]) {
                    Console.Write(i + "\t");
                }
            }*/
        }

        static void Problem9(int n) {
            int[] s = {1, 7, 11, 13, 17, 19, 23, 29, 31, 37, 
                41, 43, 47, 49, 53, 59};
            int[] s1 = {1, 13, 17, 29, 37, 41, 49, 53};
            int[] s2 = {7, 19, 31, 43};
            int[] s3 = {11, 23, 47, 59};
            bool[] a = new bool[n+1];
            a[2] = true;
            a[3] = true;
            a[5] = true;
            double sqrN = Math.Sqrt(n);
            int m;
            for (int x = 1; x < sqrN; ++x) {
                for (int y = 1; y < sqrN; y += 2) {
                    m = 4 * x * x + y * y;
                    if (m <= n && s1.Contains(m % 60)) {
                        a[m] ^= true;
                    }
                }
            }
            for (int x = 1; x < sqrN; x += 2) {
                for (int y = 2; y < sqrN; y += 2) {
                    m = 3 * x * x + y * y;
                    if (m <= n && s2.Contains(m % 60)) {
                        a[m] ^= true;
                    }
                }
            }
            for (int x = 2; x < sqrN; ++x) {
                for (int y = x - 1; y >= 1; y -= 2) {
                    m = 3 * x * x - y * y;
                    if (m <= n && s3.Contains(m % 60)) {
                        a[m] ^= true;
                    }
                }
            }
            foreach(int x in s) {
                for (int w = 0; w < n/60; w++) {
                    m = 60* w + x;
                    if (m <= n && a[m]) {
                        for (int i = m * m; i < n; i += m * m) {
                            a[i] = false;
                        }
                    }
                }
            }
            /*for(int i = 0; i < n; ++i) {
                if (a[i]) {
                    Console.Write(i + "\t");
                }
            }*/
        }

        static int[] createIntMassive(int n) {
            Random rnd = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; ++i) {
                a[i] = rnd.Next(-100, 100);
            }
            return a;
        }
        static void Problem10() {
            int n = 100;
            int[] a = createIntMassive(n);
            int s = 0;
            foreach (int i in a) {
                s += i;
            }
            int s2 = 0;
            foreach (int i in a) {
                if (i % 6 == 0) {
                    ++s2;
                }
            }
            int s3 = 0;
            foreach (int i in a) {
                if (i < 0) {
                    ++s3;
                }
            }
            int s4 = 1;
            foreach (int i in a) {
                if (i % 5 == 0) {
                    s4 *= i;
                }
            }
            int s5 = 0;
            for (int i = 1; i < n; ++i) {
                if (a[i-1] * a[i] < 0) {
                    ++s5;
                }
            }
            Random rnd = new Random();
            int x = rnd.Next(-100, 100);
            int xIndex = -1;
            for (int i = 0; i < n; ++i) {
                if (a[i] == x) {
                    Console.WriteLine("Yes");
                    xIndex = i;
                    break;
                }
            }            
            if (xIndex == -1) {
                Console.WriteLine("No");
            } 
            else {
                int s6 = 0;
                for (int i = 0; i < xIndex; ++i) {
                    s6 += a[i];
                }
                int s7 = 1;
                for (int i = xIndex + 1; i < n; ++i) {
                    if (a[i] % 2 == 1) {
                        s7 *= a[i];
                    }
                }
            }

        }

        private static bool IsLoginValid(string login) {
            login = Regex.Replace(login, @"^\s+|\s+$", "");
            Regex regex = new Regex(@"^[a-z-[aeiou]]{4}[0-9]{4}$", RegexOptions.IgnoreCase);
            if (regex.IsMatch(login)) {
                return true;
            }
            return false;
        }

        private static bool IsPasswordValid(string password) {
            Regex regex = new Regex(@"^(?=.*[0-9])(?=.*[A-Z])(?=.*[a-z]).{8,}&");
            if (regex.IsMatch(password)) {
                return true;
            }
            return false;
        }

        public static void Problem13() {
            string Login;
            /*do {
                System.Console.WriteLine("Login:");
                Login = System.Console.ReadLine();
            } while (!IsLoginValid(Login));//*/
            string Password;
            do {
                System.Console.WriteLine("Password:");
                Password = System.Console.ReadLine();
            } while (!IsPasswordValid(Password));
        }

        public static void Problem14() {
            string Str = System.Console.ReadLine();
            StringBuilder StrB = new StringBuilder();
            int Count = 0;
            foreach (char c in Str) {
                if (c >= '0' && c <= '9') {
                    ++Count;
                    StrB.Append(c);
                }
            }
            System.Console.WriteLine("Count = {0}", Count);
            System.Console.WriteLine(StrB);
        } 
        
        //в двочиной или 16 ч каждый символ в системе
        private static bool IsNumberValidForNumSys(string number, int b) {
            foreach (char C in number) {
                if (b < 10) {
                    if (C < '0' || C >= '0' + b) {
                        return false;
                    }
                } 
                else {
                    if (C < '0' || C > '9' && C < 'A' || C >= 'A' + b - 10){
                        return false;
                    }
                }
            }
            return true;
        }

        private static int ConvertToDec(string number, int numSys) {
            int Decimal = 0;
            int k = number.Length - 1;
            foreach(char c in number) {
                if (c >= 'A') {
                    Decimal += (int)Math.Pow(numSys, k) * (c - 'A' + 10);
                }
                else {
                    Decimal += (int)Math.Pow(numSys, k) * (c - '0');
                }
                --k;
            }
            return Decimal;
        }
        private static string ConvertFromDec(int number, int b) {
            if (number == 0) {
                return "0";
            }
            StringBuilder SB = new StringBuilder();
            char C;
            while (number > 1) {            
                if (number % b > 9) {
                    C = (char)(number % b + 'A' - 10);
                } 
                else {
                    C = (char)(number % b + '0');
                }
                SB.Append(C);
                number /= b;
            } 
            if (number > 0) {
                SB.Append(number);
            }
            char[] a = SB.ToString().ToCharArray();
            Array.Reverse(a);
            return new String(a);
        }
        public static void Problem15() {
            System.Console.WriteLine(IsNumberValidForNumSys("010100101010011", 2));
        }

        static void Main(string[] args) {
            /*Dog model = new Dog();
            DogView view = new DogView();
            DogController Dog1 = new DogController(model, view);
            Dog1.Name("Жучка");//*/
            //Problem13();
        }
    }
}
