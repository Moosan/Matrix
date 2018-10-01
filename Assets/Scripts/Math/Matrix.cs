using System.Collections.Generic;
using UnityEngine;

namespace MATH
{
    public class Matrix
    {
        private int Height { get; set; }
        private int Width { get; set; }
        private Fraction[][] Elements { get; set; }
        public Matrix E()
        {
            var e = new Matrix(this.Height, this.Width);
            for (var i = 0; i < this.Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    if (i == j) e.Elements[i][j] = new Fraction(1);
                    else e.Elements[i][j] = new Fraction(0);
                }
            }
            return e;
        }

        public Matrix(int height, int width)
        {
            Height = height;
            Width = width;
            Elements = new Fraction[height][];
            for (var i = 0; i < Elements.Length; i++)
            {
                Elements[i] = new Fraction[width];
                for (var j = 0; j < Elements[i].Length; j++)
                {
                    Elements[i][j] = new Fraction(0);
                }
            }

        }
        public Matrix(IList<Fraction[]> x) {
            Height = x.Count;
            Width = x[0].Length;
            for(var i = 0; i < Height; i++)
            {
                Elements[i] = new Fraction[i];
                for (var j = 0; j < Width; j++) {
                    Elements[i][j] = new Fraction();
                    Elements[i][j] = x[i][j];
                }
            }
        }

        public Fraction Element(int i,int j)
        {
            return Elements[i][j];
        }

        public int height()
        {
            return Height;
        }

        public int width()
        {
            return Width;
        }

        public override string ToString()
        {
            string result="";
            foreach (var array in Elements)
            {
                string str = "";
                int length = array.Length;
                int count = 0;
                foreach (var elem in array)
                {
                    str += elem.ToString();
                    count++;
                    if (length == count)
                    {
                        str += "\n";
                        break;
                    }
                    str += ",";
                }
                result += str;
            }
            return result;
        }

        public double[][] ToDouble()
        {
            var result = new double[Height][];
            for (int i = 0; i < Height; i++)
            {
                result[i]=new double[Width];
                for (int j = 0; j < Width; j++)
                {
                    result[i][j] = Elements[i][j].ToDouble();
                }
            }
            return result;
        }

        public double[][] ToDouble(int n)
        {
            var result = new double[Height][];
            for (int i = 0; i < Height; i++)
            {
                result[i] = new double[Width];
                for (int j = 0; j < Width; j++)
                {
                    result[i][j] = Elements[i][j].ToDouble(n);
                }
            }
            return result;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            var c = new Matrix(a.Height, a.Width);
            for (var i = 0; i < c.Elements.Length; i++)
            {
                for (var j = 0; j < c.Elements[i].Length; j++)
                {
                    c.Elements[i][j] = a.Elements[i][j] + b.Elements[i][j];
                }
            }
            return c;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            var c = new Matrix(a.Height, a.Width);
            for (var i = 0; i < c.Elements.Length; i++)
            {
                for (var j = 0; j < c.Elements[i].Length; j++)
                {
                    c.Elements[i][j] = a.Elements[i][j] - b.Elements[i][j];
                }
            }
            return c;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            var c = new Matrix(a.Height, b.Width);
            if (a.Width == b.Height)
            {
                for (var i = 0; i < c.Height; i++)
                {
                    for (var j = 0; j < c.Width; j++)
                    {
                        c.Elements[i][j] = new Fraction(0);
                        for (var k = 0; k < a.Width; k++)
                        {
                            c.Elements[i][j] += c.Elements[i][j] + a.Elements[i][k]*b.Elements[k][j];
                        }
                    }
                }
            }
            else
            {
                c = new Matrix(1, 1);
                c.Elements[0][0] = new Fraction(0);
            }
            return c;
        }

        public static Matrix operator *(Fraction a, Matrix b)
        {
            var c=new Matrix(b.Height,b.Width);
            for (var i = 0; i < c.Height; i++)
            {
                for (var j = 0; j < c.Width; j++)
                {
                    if (i == 0) c.Elements[i][j] = a;
                    else c.Elements[i][j] = new Fraction(0);
                }
            }
            return c*b;
        }

        public static Matrix operator *(int a, Matrix b)
        {
            var c=new Fraction(a);
            return c*b;
        }

        public static Matrix operator /(Matrix a, Matrix b)
        {
            return a*Reverse(b);
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
                        pow = a * Pow(a, b - 1);
                    }
                    break;
            }
            return pow;
        }

        public Fraction Determinant()
        {
            var elements = Elements;
            var determinant = new Fraction(0);
            if (Height == 2 && Width == 2)
            {
                determinant = elements[0][0] * elements[1][1] - elements[0][1] * elements[1][0];
            }
            else if (Height > 2 && Height == Width)
            {
                var matrixArray = new Matrix[Height];
                for (var i = 0; i < elements.Length; i++)
                {
                    matrixArray[i] = new Matrix(Height-1,Width-1);
                    for (var j = 0; j < Height; j++)
                    {
                        for (var k = 0; k < Width; k++)
                        {
                            if (i > j)
                            {
                                matrixArray[i].Elements[j][k] = elements[j][k + 1];
                            }
                            else if (i < j)
                            {
                                matrixArray[i].Elements[j - 1][k] = elements[j][k + 1];
                            }
                        }
                    }
                    determinant += matrixArray[i].Determinant()*elements[i][0]*Pow(-1, i);
                }
            }
            return determinant;
        }

        public static Fraction Determinant(Matrix matrix)
        {
            return matrix.Determinant();
        }

        public static Matrix Step(Matrix matrix)
        {
            var elements = matrix.Elements;
            for (var i = 0; i < matrix.Height; i++)
            {
                for (var j = 0; j < matrix.Width; j++)
                {
                    if (i != j) continue;
                    if (elements[i][j] == new Fraction(0))
                    {
                        var end = true;
                        for (var k = i + 1; k < matrix.Height; k++)
                        {
                            if (elements[k][j] == new Fraction(0)) continue;
                            var b = new Fraction[matrix.Width];
                            for (var l = 0; l < matrix.Width; l++)
                            {
                                b[l] = elements[i][l];
                            }
                            for (var l = 0; l < matrix.Width; l++)
                            {
                                elements[i][l] = elements[k][l];
                            }
                            for (var l = 0; l < matrix.Width; l++)
                            {
                                elements[k][l] = b[l];
                            }
                            end = false;
                            break;
                        }
                        if (end) break;
                    }
                    var t = elements[i][j];
                    for (var n = 0; n < matrix.Width; n++)
                    {
                        elements[i][n] = elements[i][n] / t;
                    }
                    for (var m = 0; m < matrix.Height; m++)
                    {
                        if (m == i || elements[m][j] == new Fraction(0)) continue;
                        var u = elements[m][j];
                        for (var n = 0; n < matrix.Width; n++)
                        {
                            elements[m][n] -= elements[i][n] * u;
                        }
                    }
                }
            }
            return matrix;
        }

        public static Matrix Reverse(Matrix matrix)
        {
            var determinant = matrix.Determinant();
            var matrix1 = new Matrix(matrix.Height, matrix.Width);
            for (var i = 0; i < matrix.Height; i++)
            {
                for (var j = 0; j < matrix.Width; j++)
                {
                    matrix1.Elements[i][j] = new Fraction(0);
                    var matrix2 = new Matrix(matrix.Height - 1, matrix.Width - 1);
                    for (var k = 0; k < matrix.Height; k++)
                    {
                        if (k < i)
                        {
                            for (var l = 0; l < matrix.Width; l++)
                            {
                                if (l < j)
                                {
                                    matrix2.Elements[k][l] = matrix.Elements[k][l];
                                }
                                else if (l > j)
                                {
                                    matrix2.Elements[k][l - 1] = matrix.Elements[k][l];
                                }
                            }
                        }
                        else if (k > i)
                        {
                            matrix2.Elements[k - 1] = new Fraction[matrix.Width - 1];
                            for (var l = 0; l < matrix.Width; l++)
                            {
                                if (l < j)
                                {
                                    matrix2.Elements[k - 1][l] = matrix.Elements[k][l];
                                }
                                else if (l > j)
                                {
                                    matrix2.Elements[k - 1][l - 1] = matrix.Elements[k][l];
                                }
                            }
                        }
                    }
                    matrix1.Elements[i][j] = (int)Mathf.Pow(-1, i + j) * matrix2.Determinant() / determinant;
                }
            }
            return Transposition(matrix1);
        }

        public static Matrix Transposition(Matrix a)
        {
            var transposition = new Matrix(a.Width,a.Height);
            for (var i = 0; i < a.Height; i++)
            {
                for (var j = 0; j < a.Width; j++)
                {
                    for (var k = 0; k < a.Height; k++)
                    {
                        transposition.Elements[j][k] = a.Elements[k][j];
                    }
                }
            }
            return transposition;
        }
    }
}
    
   
