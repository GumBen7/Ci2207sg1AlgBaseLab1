using System;
using System.Text;
using System.Globalization;
class Problem3_3 {
    public static void Work() {
        var input = Console.ReadLine().Split();
        var b = int.Parse(input[0]);
        var k = int.Parse(input[1]);
        var n = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        StringBuilder str = new StringBuilder("0.");
        int w;
        for (; k > 0; --k) {
            n *= b;
            w = (int)n;
            if (w < 10) {
                str.Append(w);
            }
            else {
                str.Append((char)('a' + w - 10));
            }
            n -= w;
            if (n == 0) {
                break;
            }
            var cf = false;
            if (k == 0) {
                do {
                    n *= b;
                    w = (int)n;
                    if (w < (double)b/2 - 1) {
                        break;
                    }
                    if (w >= )
                } while (true);
            }
        }
        while (str[str.Length-1] == '0') {
            --str.Length;
        }
        Console.WriteLine(str);
        var t = 3;
    }
}