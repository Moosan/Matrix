using UnityEngine;

namespace MATH
{
    public class Complex {
        public Fraction Re;
        public Fraction Im;
        public double Arg;
        public Complex(Fraction a, Fraction b)
        {
            Re = a;
            Im = b;
        }
        public Complex(Fraction a)
        {
            Re = a;
            Im = new Fraction(0);
        }
        public Complex(int a)
        {
            Re = new Fraction(a);
            Im = new Fraction(0);
        }
        public Complex()
        {
            Re = new Fraction(0);
            Im = new Fraction(0);
        }
        public override string ToString()
        {
            string result = "";
            if (Re.Up != 0)
            {
                result += Re.ToString();
                if (Im.Up == 0) return result;
                result += "+"+ Im+"i";
                return result;
            }
            if (Im.Up != 0)
            {
                result+=Im+"i";
                return result;
            }
            return "0";
        }
        public static Complex operator +(Complex x,Complex y)
        {
            return new Complex(x.Re+y.Re, x.Im+y.Im);
        }
        public static Complex operator +(Complex x,int y) {
            return x + new Complex(y);
        }
        public static Complex operator +(int x,Complex y)
        {
            return new Complex(x) + y;
        }
        public static Complex operator +(Complex x,Fraction y)
        {
            return x + new Complex(y);
        }
        public static Complex operator +(Fraction x,Complex y)
        {
            return new Complex(x) + y;
        }
        public static Complex operator -(Complex x,Complex y)
        {
            return new Complex(x.Re-y.Re, x.Im-y.Im);
        }
        public static Complex operator -(Complex x, int y)
        {
            return x - new Complex(y);
        }
        public static Complex operator -(int x, Complex y)
        {
            return new Complex(x) - y;
        }
        public static Complex operator -(Complex x, Fraction y)
        {
            return x - new Complex(y);
        }
        public static Complex operator -(Fraction x, Complex y)
        {
            return new Complex(x) - y;
        }
        public static Complex operator *(Complex x,Complex y)
        {
            return new Complex(x.Re*y.Re+x.Im*y.Im, x.Im*y.Re-x.Re*y.Im);
        }
        public static Complex operator *(Complex x, int y)
        {
            return x * new Complex(y);
        }
        public static Complex operator *(int x, Complex y)
        {
            return new Complex(x) * y;
        }
        public static Complex operator *(Complex x, Fraction y)
        {
            return x * new Complex(y);
        }
        public static Complex operator *(Fraction x, Complex y)
        {
            return new Complex(x) * y;
        }
        public static Complex operator /(Complex x,Complex y)
        {
            var a = new Fraction(y.Re * y.Re + y.Im * y.Im);
            return new Complex((x.Re * y.Re + x.Im * y.Im) / a,(x.Im*y.Re-x.Re*y.Im)/a);
        }
        public static Complex operator /(Complex x, int y)
        {
            return x / new Complex(y);
        }
        public static Complex operator /(int x, Complex y)
        {
            return new Complex(x) / y;
        }
        public static Complex operator /(Complex x, Fraction y)
        {
            return x / new Complex(y);
        }
        public static Complex operator /(Fraction x, Complex y)
        {
            return new Complex(x) / y;
        }
    }
}
