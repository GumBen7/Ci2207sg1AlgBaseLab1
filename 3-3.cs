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
        var cf = false;
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
            } //15 6 0,123456 0,1cb9e6
            //3 6 0.234 0.200220
            if (k == 1) {
                do {
                    n *= b;
                    w = (int)n;
                    if (w < (double)b/2 - 1) {
                        break;
                    }
                    if (w >= (double)b/2) {
                        cf = true;
                        break;
                    }
                } while (true);
            }//*/
        }
        if (cf) {
            int a;
            char c;
            var m = 1;
            do {
                c = str[str.Length-m];
                if (c <= '9') {
                    a = c - '0';
                }
                else {
                    a = c - 'a' + 10;
                }
                ++a;
                if (a < b) {
                    if (a < 10) {
                        str[str.Length-m] = (char)(a + '0');
                    }
                    else {
                        str[str.Length-m] = (char)(a + 'a' - 10);
                    }
                    break;
                }
                else {

                }
                ++m;
            } while (true);
        }
        while (str[str.Length-1] == '0') {
            --str.Length;
        }
        Console.WriteLine(str);
    }
}