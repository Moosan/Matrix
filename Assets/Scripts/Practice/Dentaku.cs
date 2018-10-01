using UnityEngine;

namespace Assets.Scripts
{
    public class Dentaku : MonoBehaviour {
        public static int[] n = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static int[] N;
        void Start () {
	
        }
        public static void make()
        {
        
        }
        public static int plusone(int a)
        {
            int A = 0;
            return A;
        }
        public static int minusone(int a)
        {
            int A = 0;
            int[] c=new int[N.Length];
            for (int i = 0; i < N.Length; plusone(i))
            {
                c[i] = absreverse(n[i]);
            }
            if (a <= 0)
            {
                A = c[abs(a)];
            }
            else
            {
                a = a - 1;
            }
            return A;
        }
        public static int plus(int a, int b)
        {
            for (int i = 0; i < abs(b); plusone(i))
            {
                a = plusone(a);
            }
            return a;
        }
        public static int abs(int a)
        {
            int A = 0;
            if (a >= 0)
            {
                A = a;
            }
            else
            {
                A = -a;
            }
            return A;
        }
        public static int absreverse(int a)
        {
            int A = 0;
            if (a >= 0)
            {
                A = -a;
            }
            else
            {
                A = a;
            }
            return A;
        }
        public static int multiply(int a, int b)
        {
            int[][] c=new int[abs(a)][];
            int A = 0;
            for (int i = 0; i < abs(a); plusone(i))
            {
                c[i] = new int[abs(b)];
                A = plus(A, c[i].Length);
            }
            if ((a >= 0 && b >= 0) || (a < 0 && b < 0))
            {
            }
            else
            {
                A = -A;
            }
            return A;
        }
    }
}
