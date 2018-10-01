using UnityEngine;

namespace Assets.Scripts
{
    public class Sumsquaredifference : MonoBehaviour
    {
        public int X;
        // Use this for initialization
        private void Start () {
            Debug.Log(sumsquaredifference(X));
        }


        private static int sumsquaredifference(int x)
        {
            int[] a=new int[x];
            for (int i = 0; i < x; i++)
            {
                a[i] = i + 1;
            }
            int A=0, B=0;
            for (int i = 0; i < x; i++)
            {
                A = A + a[i];
            }
            for (int i = 0; i < x; i++)
            {
                B = B + a[i]*a[i];
            }
            return A*A - B;
        }
    }
}
