using UnityEngine;
using System.Collections;
public class keiro : MonoBehaviour {
    public int a, b;
    public static int[] q;
	void Start ()
    {
        Debug.Log(f(a, b));
	}
    public static long f(long a,long b)
    {
        long[][] k = new long[a + 1][];
        for(long i = 0; i < k.Length; i++)
        {
            k[i] = new long[b+1];
        }
        return Memof(a, b, k);
    }
    public static long Memof(long a, long b, long[][] k)
    {
        if (a == 0 || b == 0) return 1;
            k[a][b] = Memof(a - 1, b, k) + Memof(a, b - 1, k);
            return k[a][b];
    }
}

