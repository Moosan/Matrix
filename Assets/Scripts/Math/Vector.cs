using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MATH
{
    public class Vector
    {
        public Fraction X,Y,Z;

        public Vector()
        {
            X = new Fraction();
            Y = new Fraction();
            Z = new Fraction();
        }

        public Vector(Fraction x, Fraction y, Fraction z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(Fraction x, Fraction y)
        {
            X = x;Y=y;Z=new Fraction();
        }

        public Vector(int x, int y, int z)
        {
            X = new Fraction(x);
            Y = new Fraction(y);
            Z = new Fraction(z);
        }

        public Fraction Length()
        {
            return X*Y*Z;
        }
        public static Vector operator +(Vector a,Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Fraction Scolor(Vector a, Vector b)
        {
            return a.X*b.X + a.Y*b.Y + a.Z*b.Z;
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(
                a.Y*b.Z - b.Y*a.Z,
                a.Z*b.X - b.Z*a.X,
                a.X*b.Y - b.X*a.Y
                );
        }
    }
}
