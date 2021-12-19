using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Fractions
    {

        public int ch;
        public int zn;


        public Fractions(int x, int y)
        {
            ch = x; zn = y;
        }

        public Fractions(int x)
        {
            ch = x; zn = 1;
        }

        public Fractions(int n, int x, int y)
        {
            ch = y * n + x; zn = y;
        }


        public static double ToDouble(int ch, int zn)
        {
            return (double)ch / zn;
        }


        public static Fractions operator +(Fractions a, Fractions b)
        {
            return new Fractions(a.ch * b.zn + b.ch * a.zn, a.zn * b.zn);
        }

        public static Fractions operator -(Fractions a, Fractions b)
        {
            return new Fractions(a.ch * b.zn - b.ch * a.zn, a.zn * b.zn);
        }

        public static Fractions operator *(Fractions a, Fractions b)
        {
            return new Fractions(a.ch * b.ch, b.zn * a.zn);
        }

        public static Fractions operator /(Fractions a, Fractions b)
        {
            return new Fractions(a.ch * b.zn, b.ch * a.zn);
        }

        public override string ToString() => $"{ch} / {zn}";


        public static bool Znak(int ch, int zn)
        {
            if (ch * zn >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int this[int index]
        {
            get { return (index == 0) ? ch : zn; }
        }
        public delegate void Delegat(Fractions x, int y);
        public event Delegat MyEventCh;
        public event Delegat MyEventZn;
        public int Ch
        {
            get { return ch; }
            set { MyEventCh(this, value); ch = value; }
        }
        public int Zn
        {
            get { return zn; }
            set { MyEventZn(this, value); zn = value; }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Fractions a = new Fractions(4, 3);
            Fractions a1 = new Fractions(4);
            Fractions a2 = new Fractions(4, 3, 5);
            Fractions b = new Fractions(1, 2);
            Fractions b1 = new Fractions(2);
            Fractions b2 = new Fractions(1, 2, 4);
            Console.WriteLine(Fractions.ToDouble(a.ch, a.zn));
            Console.WriteLine(Fractions.ToDouble(a1.ch, a1.zn));
            Console.WriteLine(Fractions.ToDouble(a2.ch, a2.zn));
            Console.WriteLine(Fractions.Znak(a.ch, a.zn));
            Console.WriteLine("Сложение: {0}", a + b);
            Console.WriteLine("Сложение: {0}", a1 + b1);
            Console.WriteLine("Сложение: {0}", a2 + b2);
            Console.WriteLine("Вычитание: {0}", a - b);
            Console.WriteLine("Вычитание: {0}", a1 - b1);
            Console.WriteLine("Вычитание: {0}", a2 - b2);
            Console.WriteLine("Умножение: {0}", a * b);
            Console.WriteLine("Умножение: {0}", a1 * b1);
            Console.WriteLine("Умножение: {0}", a2 * b2);
            Console.WriteLine("Деление: {0}", a / b);
            Console.WriteLine("Деление: {0}", a1 / b1);
            Console.WriteLine("Деление: {0}", a2 / b2);
            a.Ch = 10;
            a.Zn = 11;
            a.MyEventCh += MyMetod;
            a.MyEventZn += MyMetod1;
            Console.WriteLine("{0}, {1}", a.ch, a.zn);
            Console.WriteLine(a[0] + "/" + a[1]);
            Console.WriteLine(a.Ch + "/" + a.Zn);
     
            Console.ReadKey();
        }
        public static void MyMetod(Fractions x, int y)
        {
            Console.WriteLine("изменился числитель");
        }
        public static void MyMetod1(Fractions x, int y)
        {
            Console.WriteLine("изменился знаменатель");
        }
    }
}
