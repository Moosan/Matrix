using UnityEngine;
using System.Collections;
using System.Reflection.Emit;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {
    public long n;
    public static long[] a;
    public static long[] b;
	// Use this for initialization
	void Start () {
        b=new long[n];
        prime(n,b);
	}
	void Update () {
	    if (Input.GetKey(KeyCode.Q))
        {
            if (a.Length < n)
            {
                prime(n, b);
                b = new long[n];
                for (int i = 0; i < b.Length; i++)
                {
                    b[i] = a[i];
                }
            }
            else
            {
                Debug.Log(b[n-1]);
            }
        }
	}
    public void prime(long n,long[] b)
    {
        a = new long[n];
        a[0] = 2;
        a[1] = 3;
        for (long i = 2; i < b.Length&&b[i]!=0; i++)
        {
            a[i] = b[i];
        }
        for (long i = 2; i < n; i++)
        {
            a[i] = newK(i - 1);
        }
        print(a[n-1]);
    }
    public static long newK(long k)
    {
        int q = 2;
        bool[] r = new bool[40];
        for (int i = 0; i < 40; i++)

        {
            r[i] = false;
        }
        for (int i = 1; i < k; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                if ((2 * (j + 1) % a[i] + a[k] % a[i]) % a[i] == 0) r[j] = true;
            }
        }
        for (int i = 1; true; i++)
        {
            if (!r[i - 1])
            {
                q = 2 * i;
                break;
            }
        }
        return a[k] + q;
    }
}
