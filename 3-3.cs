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
        for (; k > 0; --k) {
            n *= b;
            var w = (int)n;
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
        }
        Console.WriteLine(str);
    }
}