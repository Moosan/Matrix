using System;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;

namespace MATH
{
    [SerializeField]
    public class Fraction
    {
        public int Up { get; set; }
        private int _down;

        public int Down
        {
            get { return _down; }
            set
            {
                if (value != 0) _down = value;
                else
                {
                    Debug.Log("分母に0が代入されています。");
                }
            }
        }
        public Fraction(int up)
        {
            Up = up;
            Down = 1;
        }
        public Fraction(int up, int down) {
            Up = up;
            if (down == 0)
            {
                Up = up / down;
            }
            Down = down;
        }
        public Fraction(Fraction a)
        {
            Up = a.Up;
            Down = a.Down;
        }
        public Fraction()
        {
            Up = 0;
            Down = 1;
        }
        public override string ToString()
        {
            if (Down == 1) return Up.ToString();
            if (Up >= 0) return  Up + "/" + Down;
            return Up + "/" + Down;
        }

        public double ToDouble()
        {
            return Up/(double)Down;
        }

        public double ToDouble(int index)
        {
            double result=0;
            for (int i = 0; i <= index; i++)
            {
                int value = (i+1)*Up/Down;
                if (value >= 1)
                {
                    result += value/Ten(i);
                }
            }
            return result;
        }

        public static double Ten(int n)
        {
            const double ten = 10.000000000000000000000000000000000000000000;
            double result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= ten;
            }
            return result;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            var c = new Fraction
            {
                Down = a.Down*b.Down,
                Up = a.Up*b.Down + b.Up*a.Down
            };
            return Reduce(c);
        }
        public static Fraction operator +(int a,Fraction b)
        {
            return new Fraction(a) + b;
        }
        public static Fraction operator +(Fraction a,int b)
        {
            return a + new Fraction(b);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            var c = new Fraction
            {
                Down = a.Down*b.Down,
                Up = a.Up*b.Down - b.Up*a.Down
            };
            return Reduce(c);
        }
        public static Fraction operator -(int a,Fraction b)
        {
            return new Fraction(a) + b;
        }
        public static Fraction operator -(Fraction a,int b)
        {
            return a + new Fraction(b);
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            var c = new Fraction
            {
                Up = a.Up*b.Up,
                Down = a.Down*b.Down
            };
            return Reduce(c);
        }
        public static Fraction operator *(int a,Fraction b)
        {
            return new Fraction(a) * b;
        }
        public static Fraction operator *(Fraction a,int b)
        {
            return a * new Fraction(b);
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            var c = new Fraction
            {
                Up = a.Up*b.Down,
                Down = a.Down*b.Up
            };
            return Reduce(c);
        }
        public static Fraction operator /(int a,Fraction b)
        {
            return new Fraction(a) / b;
        }
        public static Fraction operator /(Fraction a,int b)
        {
            return a / new Fraction(b);
        }
        public static Fraction operator ^(Fraction a,Fraction b)
        {
            var c = new Fraction(1);
            for(var i = 0; i < b.Up; i++)
            {
                c = c * a;
            }
            if (b.Down != 1) Debug.Log("無理数は未定義です");
            return c;
        }
        public static Fraction operator ^(Fraction a,int b)
        {
            return a ^ new Fraction(b);
        }
        public static Fraction Reduce(Fraction a)
        {
            bool positive;
            if (a.Up >= 0)
            {
                if (a.Down >= 0) positive = true;
                else
                {
                    positive = false;
                    a.Down = -a.Down;
                }
            }else
            {
                a.Up = -a.Up;
                if (a.Down >= 0) positive = false;
                else
                {
                    positive = true;
                    a.Down = -a.Down;
                }
            }
            var r = Gcd(a.Up, a.Down);
            a.Up = a.Up / r;
            a.Down = a.Down / r;
            if (!positive) a.Up = -a.Up;
            return a;
        }

        private static int Gcd(int m, int n)
        {
            while (true)
            {
                var r = m%n;
                if (r == 0) return n;
                m = n;
                n = r;
            }
        }
    }
}
