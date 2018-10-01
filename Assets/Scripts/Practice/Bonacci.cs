using System.Collections.Generic;
using UnityEngine;

public class Bonacci : MonoBehaviour
{
    public long N;
    public long M;
	private void Main() { 
        Debug.Log(Bonaccci(N,M));
	}
    

    private static long Bonaccci(long n, long m)
    {
        var array = new long[n + 1];
        for (var i = 0; i < m - 1; i++)
        {
            array[i] = 0;
        }
        array[m - 1] = 1;
        for (var i = m; i < n+1; i++)
        {
            array[i] = BonacciMemo(i, array, m);
        }
        return array[n];
    }

    private static long BonacciMemo(long n, long[] array,long m)
    {
        long sum = 0;
        for (var i = 1; i <= m; i++)
        {
            sum += array[n - i];
        }
        return sum;
    }
}
