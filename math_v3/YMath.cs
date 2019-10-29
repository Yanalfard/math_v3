using System;
using System.Collections.Generic;
using System.Linq;

namespace math_v3
{
    public class YMath
    {
        private static int Signt(int i, int j)
        {
            if ((i + j) % 2 == 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        private static double[,] SmallerMatrix(double[,] input, int i, int j)
        {
            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            double[,] output = new double[order - 1, order - 1];
            int x = 0, y = 0;
            for (int m = 0; m < order; m++, x++)
            {
                if (m != i)
                {
                    y = 0;
                    for (int n = 0; n < order; n++)
                    {
                        if (n != j)
                        {
                            output[x, y] = input[m, n];
                            y++;
                        }
                    }
                }
                else
                {
                    x--;
                }
            }
            return output;
        }
        private static int even(int x)
        {
            return 2 * x;
        }
        private static int odd(int n)
        {
            return (2 * n) + 1;
        }
        public static int pointcountsetter(string txt1, string txt2)
        {
            //miguyad ke koja momayez ast;az rast be chap amal mikonad;;
            int ct1 = 0;
            int last1 = 0;
            int ct2 = 0;
            int last2 = 0;
            int pointcounter = 0;
            char[] t1 = txt1.ToCharArray();
            char[] t2 = txt2.ToCharArray();
            for (int i = t1.Length - 1; i >= 0; i--)
            {
                if (t1[i] == '.')
                {
                    last1 = ct1;
                    continue;
                }
                ct1++;
            }
            for (int i = t2.Length - 1; i >= 0; i--)
            {
                if (t2[i] == '.')
                {
                    last2 = ct2;
                    continue;
                }
                ct2++;
            }
            if (last1 > last2)
            {
                pointcounter = last1;
            }
            else
            {
                pointcounter = last2;
            }
            return pointcounter;
        }
        public static int intpart(double value)
        {
            //gesmate adadiye yek adad ra midahad (haman jozee sahih);;
            return Convert.ToInt32(System.Math.Floor(Convert.ToDecimal(value)));
        }
        public static bool ISprime(int x)
        {
            //check mikonad aya adad aval ast ya na;;
            bool aval = true;
            for (int i = 2; i < System.Math.Round(System.Math.Sqrt(x)) + 1; i++)
            {
                if (x % i == 0)
                {
                    aval = false;
                    break;
                }
            }
            return aval;
        }
        public static double sqrt(double input)
        {
            int time = 100;
            double ans = 1;
            while (time >= 0)
            {
                ans = 0.5 * (ans + (input / ans));
                time--;
            }
            return ans;
        }
        public static double fact(double x)
        {
            //factoriele yek megdar ra moshkas mikonad;;
            if (x == 0)
            {
                x = 1;
                return x;
            }
            else
            {
                double s = x;
                for (int a = 1; a < s; a++)
                {
                    x = x * (s - a);
                }
            }
            return x;
        }
        public static string PI(int length)
        {
            //megdare adade pi ra midahad;;
            int n = length;
            n++;
            int[] x = new int[n * 10 / 3 + 2];
            int[] r = new int[n * 10 / 3 + 2];
            int[] pi = new int[n];
            for (int j = 0; j < x.Length; j++)
                x[j] = 20;
            for (int i = 0; i < n; i++)
            {
                int carry = 0;
                for (int j = 0; j < x.Length; j++)
                {
                    int num = (int)(x.Length - j - 1);
                    int dem = num * 2 + 1;

                    x[j] += carry;

                    int q = x[j] / dem;
                    r[j] = x[j] % dem;

                    carry = q * num;
                }
                pi[i] = (x[x.Length - 1] / 10);
                r[x.Length - 1] = x[x.Length - 1] % 10; ;
                for (int j = 0; j < x.Length; j++)
                {
                    x[j] = r[j] * 10;
                }
            }
            string result = "";
            int c = 0;
            for (int i = pi.Length - 1; i >= 0; i--)
            {
                pi[i] += c;
                c = pi[i] / 10;

                result = (pi[i] % 10).ToString() + result;
            }
            return result;
        }
        public static double EXP(int power, int pricisness)
        {
            //megdare e be tavane x ra midahad;;
            double ans = 1;
            while (pricisness != 0)
            {
                ans = System.Math.Pow(power, pricisness) / fact(pricisness) + ans;
                pricisness--;
            }
            return ans;
        }
        public static double forie(double x, double n, double omega, double t, double faze)
        {
            //megdar forieiy ra moshkhas mikonad;;
            int n1 = (int)t;
            int count = 1;
            double[] a = new double[n1];
            while (count != t)
            {
                a[n1 - 1] = EXP((int)x, (int)n) * System.Math.Sin(((omega * count) + faze) * System.Math.PI);
                count++;
            }
            return a.Sum();
        }
        public static string BigAdd(string s1, string s2)
        {
            //majmue do adade bozorge reshteii ra midahad;;
            char[] num1 = s1.ToCharArray();
            char[] num2 = s2.ToCharArray();
            int sum = 0;
            int carry = 0;
            int size;
            if (s1.Length > s2.Length)
            {
                size = s1.Length + 1;
            }
            else
            {
                size = s2.Length + 1;
            }
            int[] result = new int[size];
            int index = size - 1;
            int num1index = num1.Length - 1;
            int num2index = num2.Length - 1;
            while (true)
            {
                if (num1index >= 0 && num2index >= 0)
                {
                    sum = (num1[num1index] - '0') + (num2[num2index] - '0') + carry;
                }
                else if (num1index < 0 && num2index >= 0)
                {
                    sum = (num2[num2index] - '0') + carry;
                }
                else if (num1index >= 0 && num2index < 0)
                {
                    sum = (num1[num1index] - '0') + carry;
                }
                else { break; }
                carry = sum / 10;
                result[index] = sum % 10;
                index--;
                num1index--;
                num2index--;
            }
            if (carry > 0)
            {
                result[index] = carry;
            }
            string answer = "";
            for (int i = 0; i < result.Length; i++)
            {
                answer += result[i];
            }
            return LeftZeroRemover(answer);
        }
        public static string BigMinus(string num1, string num2)
        {
            //yek reshteye adadi bozorg ra az digari kam mikonad;;
            if (Compare(num1, num2) == num2)
            {
                return null;
            }
            int counter;
            string t = "";
            if ((num1.Length) > (num2.Length))
            {
                counter = num1.Length;
            }
            else
            {
                counter = num2.Length;
            }
            int[] a = new int[(counter + 1)];
            int[] b = new int[(counter + 1)];
            int[] m = new int[(counter + 1)];
            int hf = (num1.Length - 1);
            int ls = (num2.Length - 1);
            for (int ur = 0; ur < (num1.Length); ur++)
            {
                while (hf >= 0)
                {
                    a[ur] = Convert.ToInt32(num1[hf].ToString());
                    hf--;
                    break;
                }
            }
            for (int sk = 0; sk < (num2.Length); sk++)
            {
                while (ls >= 0)
                {
                    b[sk] = Convert.ToInt32(num2[ls].ToString());
                    ls--;
                    break;
                }
            }
            for (int x = 0; x < counter; x++)
            {
                if (a[x] < b[x])
                {
                    a[x] += 10;
                    a[x + 1]--;
                    m[x] = (a[x] - b[x]);
                }
                else
                {
                    m[x] = (a[x] - b[x]);
                }
            }
            for (int p = (counter - 1); p >= 0; p--)
            {
                t += m[p].ToString();
            }
            return t;
        }
        public static string BigMul(string num1, string num2)
        {
            //megdare zarbe do reshteye adadi bozorg ra midahd;;
            int num1_len = num1.Length;
            int num2_len = num2.Length;
            char[] result = new char[num1_len + num2_len];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = '0';
            }
            int remainder = 0;
            int position = result.Length - 1;
            int m = result.Length - 1;
            for (int i = num1_len - 1; i >= 0; i--)
            {
                int multiplier = Convert.ToInt32(num1[i].ToString());
                for (int j = num2_len - 1; j >= 0; j--)
                {
                    int second = Convert.ToInt32(num2[j].ToString());
                    int last = multiplier * second + remainder + Convert.ToInt32(result[position].ToString());
                    remainder = 0;
                    int char_ans = last % 10;
                    if (last > 9)
                    {
                        remainder = last / 10;
                    }
                    result[position] = Convert.ToChar(char_ans.ToString());
                    position--;
                }
                if (remainder > 0)
                {
                    result[position] = Convert.ToChar(remainder.ToString());
                    remainder = 0;
                }
                m--;
                position = m;
            }
            if (remainder > 0)
            {
                result[position] = Convert.ToChar(remainder.ToString());
                remainder = 0;
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '0')
                {
                    result[i] = ' ';
                }
                else
                {
                    break;
                }
            }
            string lastoflast = "";
            for (int i = 0; i < result.Length; i++)
            {
                lastoflast += result[i];
            }
            return lastoflast;
        }
        public static string Bigdevide(string num1, string num2)
        {
            //megdare kharej gesmate tagsime do reshteye adadi ra midahad
            string count = "0";
            string[] nums = new string[2];
            while (true)
            {
                if (BigMinus(num1, num2) == null)
                {
                    break;
                }
                else if (BigMinus(num1, num2) == num2)
                {
                    count = BigAdd(count, "2");
                    break;
                }
                else
                {
                    num1 = BigMinus(num1, num2);
                    num1 = LeftZeroRemover(num1);
                    num2 = LeftZeroRemover(num2);
                }
                count = BigAdd(count, "1");
            }
            count = LeftZeroRemover(count);
            return count;
        }
        public static string[] Sort(string[] array)
        {
            //yek araye az reshe haye adadi ra __az kochek be bozorg__ morattab mikonad;;
            Array.Sort(array, (left, right) =>
            {
                if (left.Length != right.Length)
                {
                    return left.Length - right.Length;
                }
                return left.CompareTo(right);
            });
            return array;
        }
        public static string Compare(string x, string y)
        {
            //do rashteye adady bozorg ra mogayese karde va bozorg tarin ra midahad;;
            if (x.Length > y.Length)
            {
                y = y.PadLeft(x.Length, '0');
            }
            else if (y.Length > x.Length)
            {
                x = x.PadLeft(y.Length, '0');
            }
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < y[i]) return y;
                if (x[i] > y[i]) return x;
            }
            return y;
        }
        public static string LeftZeroRemover(string x)
        {
            //tamami sefrhaye ijad shode dar samte chap adad ra pak mikonad;;
            string last = "";
            char[] y = x.ToCharArray();
            List<char> m = y.ToList();
            while (true)
            {
                if (m[0] == '0')
                {
                    m.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < m.Count; i++)
            {
                last += m[i];
            }
            return last;
        }
        static public double Determinant(double[,] input)
        {
            //determinane yek matris ra midahad;;
            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            if (order > 2)
            {
                double value = 0;
                for (int j = 0; j < order; j++)
                {
                    double[,] Temp = SmallerMatrix(input, 0, j);
                    value = value + input[0, j] * (Signt(0, j) * Determinant(Temp));
                }
                return value;
            }
            else if (order == 2)
            {
                return ((input[0, 0] * input[1, 1]) - (input[1, 0] * input[0, 1]));
            }
            else
            {
                return (input[0, 0]);
            }
        }
        public static string Fib(int n)
        {
            string[] a = new string[n];
            a[0] = "1";
            a[1] = "1";
            for (int i = 2; i < n; i++)
            {
                a[i] = BigAdd(a[i - 1], a[i - 2]);
            }
            return LeftZeroRemover(a[a.Length - 1]);
        }
        public static double Sin(double x)
        {
            //sinuse yek megdar ra midahad;;
            double m = 0;
            for (int i = 0; i < 50; i++)
            {
                if (i % 2 == 0)
                {
                    m += (System.Math.Pow(System.Math.PI * x, odd(i))) / (fact(odd(i)));
                }
                else if (i % 2 == 1)
                {
                    m -= (System.Math.Pow(System.Math.PI * x, odd(i))) / (fact(odd(i)));
                }
            }
            return m;
        }
        public static double Cos(double x)
        {
            //cosinuse yek megdar ra midahad;;
            double m = 0;
            for (int i = 0; i < 50; i++)
            {
                if (i % 2 == 0)
                {
                    m += (System.Math.Pow(x, even(i))) / (fact(even(i)));
                }
                else if (i % 2 == 1)
                {
                    m -= (System.Math.Pow(x, even(i))) / (fact(even(i)));
                }
            }
            return m;
        }
        public static double Tan(double x)
        {
            //tanzhante yek megdar ra midahad;;
            return Sin(x) / Cos(x);
        }
        public static double Cot(double x)
        {
            //cotanjant megdar ra bar hasbe daraje midahad;;
            return Cos(x) / Sin(x);
        }
        public static string Fib_turner(int x)
        {
            if (x == 1 || x == 2)
            {
                return "1";
            }
            else
            {
                return LeftZeroRemover(BigAdd(Fib_turner(x - 1), Fib_turner(x - 2)));
            }
        }
        public static double fact_turner(int x)
        {
            if (x != 0)
            {
                return (x * fact(x - 1));
            }
            else
            {
                return 1;
            }
        }
        public static double Combine(int m, int n)
        {
            //tarkibe do adad ra midahad;;
            int k = n - m;
            return fact(n) / (fact(m) * fact(k));
        }
        public static double Varians(int[] input)
        {
            //baraye mohasebeye varians be ar miravad
            double mean = input.Average();
            double[] a = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                a[i] = System.Math.Pow((mean - input[i]), 2);
            }
            return a.Average();
        }
        public static double StandardDeviation(int[] input)
        {
            //baraye mohasebeye enherafa meyar be kar miravad;;
            return System.Math.Sqrt(Varians(input));
        }
        public static double Covarians(int[] a, int[] b)
        {
            //barayr mohasebeye covarians be kar miravad;;
            if (a.Length != b.Length)
            {
                return 0;
            }
            else
            {
                int[] ab = new int[a.Length];
                for (int i = 0; i < a.Length; i++)
                {
                    ab[i] = a[i] * b[i];
                }
                return ((ab.Sum() / a.Length) - (a.Average() * b.Average()));
            }
        }
        public static double CorrelationCoefficient(int[] a, int[] b)
        {
            //baraye mohasebeye zaribe hambastegi be kar miravad;;
            return ((Covarians(a, b)) / (System.Math.Sqrt(Varians(a)) * System.Math.Sqrt(Varians(b))));
        }
        public static string Regression(out double a, out double b, int[] x, int[] y)
        {
            //baraye mohasebeye regresione do seri az dade ha be kar miravad;;
            if (x.Length != y.Length)
            {
                a = 0;
                b = 0;
                return null;
            }
            else
            {
                double[] xp2 = new double[x.Length];
                double[] yp2 = new double[y.Length];
                double[] xy = new double[x.Length];
                for (int i = 0; i < x.Length; i++)
                {
                    xp2[i] = System.Math.Pow(x[i], 2);
                    yp2[i] = System.Math.Pow(y[i], 2);
                    xy[i] = x[i] * y[i];
                }
                a = ((x.Sum() * y.Sum()) - (x.Length * xy.Sum())) / ((System.Math.Pow(x.Sum(), 2)) - (x.Length * xp2.Sum()));
                b = ((x.Sum() * xy.Sum()) - (y.Sum() * xp2.Sum())) / ((System.Math.Pow(x.Sum(), 2)) - (x.Length * xp2.Sum()));
                return (a.ToString() + " x + " + b.ToString() + " = y");
            }
        }
        public static double ConditionalProbability(int[] space, int[] a, int[] b)
        {
            List<int> grow = new List<int>();
            int j = 0;
            while (j != b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == b[j])
                    {
                        grow.Add(b[j]);
                    }
                }
                j++;
            }
            int[] AinB = grow.ToArray();
            double P_AinB = (double)AinB.Length / (double)space.Length;
            double P_B = (double)b.Length / (double)space.Length;
            return (double)P_AinB / (double)P_B;
        }
    }
}
