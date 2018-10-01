using System;
using UnityEngine;

namespace MATH
{
    [Serializable]
    public class AMatrix
    {
        public int Row;
        public int[] A0, A1, A2, A3, A4, A5, A6, A7, A8, A9;
    }

    [Serializable]
    public class BMatrix
    {
        public int Row;
        public int[] B0, B1, B2, B3, B4, B5, B6, B7, B8, B9;
    }

    [Serializable]
    public class Number
    {
        public GameObject Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Hiku, Bar;
    }

    public class MatrixClass : MonoBehaviour
    {
        public bool
            ChoiceB,
            DoPlus,
            DoMinus,
            DoTransposition,
            DoMultiply,
            DoStep,
            DoRank,
            DoReverse,
            DoDeterminant,
            DoTrace,
            DoTaikakuka;

        private Fraction[][] _a;
        private Fraction[][] _b;
        public Fraction[][] W;
        public AMatrix Am;
        public BMatrix Bm;
        public Number Number;
        public static Fraction[][] A;
        public static Fraction[][] B;
        public static GameObject[] Nm;
        public static GameObject Camera;

        public void Start()
        {
            Camera = GameObject.FindGameObjectWithTag("MainCamera");
            Make();
            _a = new Fraction[Am.Row][];
            _b = new Fraction[Bm.Row][];
            for (var i = 0; i < Am.Row; i++)
            {
                _a[i] = A[i];
            }
            for (var i = 0; i < Bm.Row; i++)
            {
                _b[i] = B[i];
            }
            Fraction p = Determinant(_a);
            Debug.Log(p.ToString());
        }

        public void Make()
        {
            Nm = new[]
            {
                Number.Zero, Number.One,
                Number.Two, Number.Three, Number.Four, Number.Five, Number.Six,
                Number.Seven, Number.Eight, Number.Nine, Number.Hiku, Number.Bar
            };
            A = new[]
            {M(Am.A0), M(Am.A1), M(Am.A2), M(Am.A3), M(Am.A4), M(Am.A5), M(Am.A6), M(Am.A7), M(Am.A8), M(Am.A9)};
            B = new[]
            {M(Bm.B0), M(Bm.B1), M(Bm.B2), M(Bm.B3), M(Bm.B4), M(Bm.B5), M(Bm.B6), M(Bm.B7), M(Bm.B8), M(Bm.B9)};
            if (ChoiceB)
            {
                _b = new Fraction[Am.Row][];
                _a = new Fraction[Bm.Row][];
                for (var i = 0; i < Am.Row; i++)
                {
                    _b[i] = A[i];
                }
                for (var i = 0; i < Bm.Row; i++)
                {
                    _a[i] = B[i];
                }
            }
            else
            {
                _a = new Fraction[Am.Row][];
                _b = new Fraction[Bm.Row][];
                for (var i = 0; i < Am.Row; i++)
                {
                    _a[i] = A[i];
                }
                for (var i = 0; i < Bm.Row; i++)
                {
                    _b[i] = B[i];
                }
            }

            if (DoPlus)
            {
                W = PlusMatrix(_a, _b);
            }
            else if (DoMinus)
            {
                W = PullMatrix(_a, _b);
            }
            else if (DoTransposition)
            {
                W = Transposition(_a);
            }
            else if (DoMultiply)
            {
                W = MultiplyMatrix(_a, _b);
            }
            else if (DoStep)
            {
                W = Step(_a);
            }
            else if (DoRank)
            {
                W = new[] {new[] {new Fraction(Rank(_a))}};
            }
            else if (DoReverse)
            {
                W = Reverse(_a);
            }
            else if (DoDeterminant)
            {
                W = new[] {new[] {Determinant(_a)}};
            }
            else if (DoTrace)
            {
                W = new[] {new[] {Trace(_a)}};
            }
            else if (DoTaikakuka)
            {
                W = Taikakuka(_a);
            }
            else
            {
                W = A;
            }
        }


        public static void Write(int x, float a, float b)
        {
            while (true)
            {
                if (x >= 0 && x < 10)
                {
                    Dasu(x, a, b);
                }
                else if (x >= 10 && x < 100)
                {
                    Write(x/10, a - 0.1f, b);
                    x = x%10;
                    a = a + 0.1f;
                    continue;
                }
                else if (x > -10 && x < 0)
                {
                    Dasu(10, a - 0.1f, b);
                    x = -x;
                    a = a + 0.1f;
                    continue;
                }
                else if (x >= 100 && x < 1000)
                {
                    Write(x/100, a - 0.2f, b);
                    Write((x%100)/10, a, b);
                    x = (x%100)%10;
                    a = a + 0.2f;
                    continue;
                }
                else if (x <= -10 && x > -100)
                {
                    Dasu(10, a - 0.2f, b);
                    x = -x;
                    a = a + 0.1f;
                    continue;
                }
                else if (x >= 1000 && x < 10000)
                {
                    Write(x/1000, a - 0.3f, b);
                    Write(x%1000/100, a - 0.1f, b);
                    Write(x%100/10, a + 0.1f, b);
                    x = x%10;
                    a = a + 0.3f;
                    continue;
                }
                else if (x <= -100 && x > -1000)
                {
                    Dasu(10, a - 0.3f, b);
                    x = -x;
                    a = a + 0.1f;
                    continue;
                }
                else if (x >= 10000 && x < 100000)
                {
                    Write(x/10000, a - 0.4f, b);
                    Write(x%10000/1000, a - 0.2f, b);
                    Write(x%1000/100, a, b);
                    Write(x%100/10, a + 0.2f, b);
                    x = x%10;
                    a = a + 0.4f;
                    continue;
                }
                else if (x <= -1000 && x > -10000)
                {
                    Dasu(10, a - 0.4f, b);
                    x = -x;
                    a = a + 0.1f;
                    continue;
                }
                break;
            }
        }

        public static void Dasu(int x, float a, float b)
        {
            var m = new Vector3(a, -b, 0);
            //var n = Quaternion.LookRotation(m - Camera.transform.position);
            Instantiate(Nm[x], m, /*n*/new Quaternion());
        }

        public static void WriteFraction(Fraction x,float a,float b)
        {
            if (x.Down == 1)
            {
                Write(x.Up, a, b);
            }
            else
            {
                Dasu(11,a,b);
                var p = FLength(x.Up);
                var q = FLength(x.Down);
                Write(x.Up,a-0.1f*(p+1),b);
                Write(x.Down,a+0.1f*(q+1),b);
            }
        }

        public void WriteMatrix(Fraction[][] x)
        {
            for (var i = 0; i < x.Length; i++)
            {
                for (var j = 0; j < x[i].Length; j++)
                {
                    WriteFraction(x[i][j], j, i);
                }
            }
        }

        public static Fraction[][] PlusMatrix(Fraction[][] a, Fraction[][] b)
        {
            var c = new Fraction[a.Length][];
            for (var i = 0; i < a.Length; i++)
            {
                c[i] = new Fraction[a[i].Length];
                for (var j = 0; j < a[i].Length; j++)
                {
                    c[i][j]=new Fraction(0);
                    c[i][j] = a[i][j] + b[i][j];
                }
            }
            return c;
        }

        public static Fraction[][] PullMatrix(Fraction[][] a, Fraction[][] b)
        {
            var c = new Fraction[a.Length][];
            for (var i = 0; i < a.Length; i++)
            {
                c[i] = new Fraction[a[i].Length];
                for (var j = 0; j < a[i].Length; j++)
                {
                    c[i][j] = a[i][j] - b[i][j];
                }
            }
            return c;
        }

        public static Fraction[][] Transposition(Fraction[][] a)
        {
            var c = new Fraction[a[0].Length][];
            foreach (var t in a)
            {
                for (var j = 0; j < t.Length; j++)
                {
                    c[j] = new Fraction[a.Length];
                    for (var k = 0; k < a.Length; k++)
                    {
                        c[j][k] = a[k][j];
                    }
                }
            }
            return c;
        }

        public static Fraction[][] MultiplyMatrix(Fraction[][] a, Fraction[][] b)
        {
            var c = new Fraction[a.Length][];
            for (var i = 0; i < a.Length; i++)
            {
                c[i] = new Fraction[b[i].Length];
                for (var j = 0; j < b[i].Length; j++)
                {
                    c[i][j]=new Fraction(0);
                    for (var k = 0; k < a[i].Length; k++)
                    {
                        c[i][j] = c[i][j] + a[i][k]*b[k][j];
                    }
                }
            }
            return c;
        }

        public static Fraction Determinant(Fraction[][] a)
        {
            var determinant = new Fraction(0);
            if (a.Length == 2 && a[0].Length == 2)
            {
                determinant = a[0][0]*a[1][1] - a[0][1]*a[1][0];
            }
            else if (a.Length > 2 && a.Length == a[0].Length)
            {
                var c = new Fraction[a.Length][][];
                for (var i = 0; i < a.Length; i++)
                {
                    c[i] = new Fraction[a.Length - 1][];
                    for (var j = 0; j < a[i].Length - 1; j++)
                    {
                        c[i][j] = new Fraction[a[j].Length - 1];
                    }
                    for (var j = 0; j < a.Length; j++)
                    {
                        for (var k = 0; k < a[j].Length - 1; k++)
                        {
                            if (i > j)
                            {
                                c[i][j][k] = a[j][k + 1];
                            }
                            else if (i < j)
                            {
                                c[i][j - 1][k] = a[j][k + 1];
                            }
                        }
                    }
                    determinant = determinant + a[i][0]*Pow(-1, i)*Determinant(c[i]);
                }
            }
            return determinant;
        }

        public static int Pow(int a, int b)
        {
            var pow = 1;
            switch (b)
            {
                case 0:

                    break;
                case 1:
                    pow = a;
                    break;
                default:
                    if (b > 1)
                    {
                        pow = a*Pow(a, b - 1);
                    }
                    break;
            }
            return pow;
        }

        public static int Rank(Fraction[][] a)
        {
            var rank = 0;
            var b = Step(a);
            for (var i = 0; i < a.Length; i++)
            {
                if (b[i][i] != new Fraction(0))
                {
                    rank++;
                }
            }
            return rank;
        }

        public static Fraction Trace(Fraction[][] a)
        {
            return Determinant(Taikakuka(a));
        }

        public static bool Seisoku(Fraction[][] a)
        {
            if (Determinant(a) != new Fraction(0)) return true;
            print("正則行列ではありません");
            return false;
        }

        public static Fraction[][] Taikakuka(Fraction[][] a)
        {
            var b = 0;
            var c = new Fraction[a.Length][];
            if (!Seisoku(a))
            {
                Debug.Log("正則行列ではありません。");
                c = new[] {new[] {new Fraction(0) }};
            }
            else
            {
                for (var λ = 1; b != a.Length; λ++)
                {
                    var e = new Fraction[a.Length][];
                    for (var i = 0; i < a.Length; i++)
                    {
                        e[i] = new Fraction[a[i].Length];
                        for (var j = 0; j < a[i].Length; j++)
                        {
                            if (i == j)
                            {
                                e[i][j] = new Fraction(λ);
                            }
                            else
                            {
                                e[i][j] = new Fraction(0);
                            }
                        }
                    }
                    if (Determinant(PullMatrix(a, e)) == new Fraction(0))
                    {
                        c[b] = new Fraction[a.Length];
                        for (var l = 0; l < a.Length; l++)
                        {
                            if (b == l)
                            {
                                c[b][l] = new Fraction(λ);
                            }
                            else
                            {
                                c[b][l] = new Fraction(0);
                            }
                        }
                        b++;
                    }
                    if (b == a.Length) continue;
                    {
                        for (var i = 0; i < a.Length; i++)
                        {
                            for (var j = 0; j < a[i].Length; j++)
                            {
                                if (i == j)
                                {
                                    e[i][j] = new Fraction(-λ);
                                }
                                else
                                {
                                    e[i][j] = new Fraction(0);
                                }
                            }
                        }
                        if (Determinant(PullMatrix(a, e)) != new Fraction(0)) continue;
                        c[b] = new Fraction[a.Length];
                        for (var l = 0; l < a.Length; l++)
                        {
                            if (b == l)
                            {
                                c[b][l] = new Fraction(-λ);
                            }
                            else
                            {
                                c[b][l] = new Fraction(0);
                            }
                        }
                        b++;
                    }
                }
            }
            return c;
        }

        public static Fraction[][] Step(Fraction[][] a)
        {
            for (var i = 0; i < a.Length; i++)
            {
                for (var j = 0; j < a[i].Length; j++)
                {
                    if (i != j) continue;
                    if (a[i][j] == new Fraction(0))
                    {
                        var end = true;
                        for (var k = i + 1; k < a.Length; k++)
                        {
                            if (a[k][j] == new Fraction(0)) continue;
                            var b = new Fraction[a[i].Length];
                            for (var l = 0; l < a[i].Length; l++)
                            {
                                b[l] = a[i][l];
                            }
                            for (var l = 0; l < a[i].Length; l++)
                            {
                                a[i][l] = a[k][l];
                            }
                            for (var l = 0; l < a[i].Length; l++)
                            {
                                a[k][l] = b[l];
                            }
                            end = false;
                            break;
                        }
                        if (end) break;
                    }
                    var t = a[i][j];
                    for (var n = 0; n < a[i].Length; n++)
                    {
                        a[i][n] = a[i][n]/t;
                    }
                    for (var m = 0; m < a.Length; m++)
                    {
                        if (m == i || a[m][j] == new Fraction(0)) continue;
                        var u = a[m][j];
                        for (var n = 0; n < a[m].Length; n++)
                        {
                            a[m][n] -= a[i][n]*u;
                        }
                    }
                }
            }
            return a;
        }

        public static Fraction[][] Reverse(Fraction[][] a)
        {
            var determinant = Determinant(a);
            var fractions=new Fraction[a.Length][];
            for (var i = 0; i < a.Length; i++)
            {
                fractions[i]=new Fraction[a[i].Length];
                for (var j = 0; j < a[i].Length; j++)
                {
                    fractions[i][j]=new Fraction(0);
                    var c=new Fraction[a.Length-1][];
                    for (var k = 0; k < a.Length; k++)
                    {
                        if (k < i)
                        {
                            c[k] = new Fraction[a[k].Length - 1];
                            for (var l = 0; l < a[k].Length; l++)
                            {
                                if (l < j)
                                {
                                    c[k][l] = a[k][l];
                                }else if (l > j)
                                {
                                    c[k][l - 1] = a[k][l];
                                }
                            }
                        }else if (k > i)
                        {
                            c[k-1]=new Fraction[a[k].Length-1];
                            for (var l = 0; l < a[k].Length; l++)
                            {
                                if (l < j)
                                {
                                    c[k-1][l] = a[k][l];
                                }
                                else if (l > j)
                                {
                                    c[k - 1][l - 1] = a[k][l];
                                }
                            }
                        }
                    }
                    fractions[i][j] = Pow(-1,i+j)*Determinant(c)/determinant;
                }
            }
            return Transposition(fractions);
        }

        public Fraction[] M(int[] a)
        {
            var b = new Fraction[a.Length];
            for (var i = 0; i < a.Length; i++)
            {
                b[i] = new Fraction(a[i]);
            }
            return b;
        }

        public static int FLength(int x)
        {
            var a=0;
            if (x < 0)
            {
                a++;
                x = -x;
            }
            for (var i = 1;; i++)
            {
                if (x/Pow(10, i) != 0) continue;
                a =a+ i;
                break;
            }
            return a;
        }
    }
}