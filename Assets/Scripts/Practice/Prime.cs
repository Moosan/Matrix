using UnityEngine;
using System.Collections;
using UnityEditorInternal;
using System;
using System.Collections.Generic;

public class Prime : MonoBehaviour
{
    public int N;
    public bool Go;
    private const ulong Max = 18446744073709551615;

    public void Main ()
	{
	    /*for (var i = 1; i <= 4; i++)
	    {
	        Print(N,i);
	    }*/
        var time = DateTime.Now;
        Print(N,3);
        Debug.Log(DateTime.Now-time);
        time = DateTime.Now;
        Print(N, 2);
        Debug.Log(DateTime.Now - time);
        /*var T = Time.realtimeSinceStartup;
        print(SpecialPrime(N));
        print(Time.realtimeSinceStartup - T);*/
        Go = false;
	}

    public void Update()
    {
        if (Go)
        {
            Main();
        }
    }
    private static void Print(int n,int p)
    {
        //var T= Time.realtimeSinceStartup;
        var a = 0;
        switch (p)
        {
            case 1:
                a = PrimeOne(n);
                break;
            case 2:
                a = NewPrime(n);
                break;
            case 3:
                a = ToroPrime(n);
                break;
            case 4:
                a = SoPrime(n);
                break;
            case 5:
                a = PrimeAll(n);
                break;
        }
        Debug.Log(a);
        //print(Time.realtimeSinceStartup - T);
    }
    private static int PrimeOne(int n)
    {
        var a = new int[n];
        a[0] = 2;
        a[1] = 3;
        for (var i = 2; i < n; i++)
        {
            a[i] = 0;
            for (var k = a[i - 1] + 2; a[i] == 0; k = (k%3 == 1 ? k + 4 : k + 2 ) )
            {
                for (var j = 1; j <= i && a[i] == 0; j++)
                {
                    if (a[j] * a[j] <= k)
                    {
                        if (k % a[j] == 0) break;
                    }
                    else a[i] = k;
                }
            }
        }
        return a[n - 1];
    }
    private static void PrimeTwo(int n)
    {
        var a=new int[n];
        a[0] = 2;
        a[1] = 3;
        a[2] = 5;
        for (var i = 3; i < n; i++)
        {
            a[i] = 0;
            for (var k = NewK(a[i - 1],a) ; a[i] == 0; k =NewK(k,a))
            {
                for (var j = 1; j <= i&&a[i]==0; j++)
                {
                    if (a[j]*a[j] <= k)
                    {
                        if (k%a[j] == 0) break;
                    }
                    else a[i] = k;
                }
            }
        }
        //print(a[n-1]);
    }
    private static int NewK(int k,int[] a)
    {
        int q;
        var r=new bool[40];
        for (var i = 0; i < 40; i++)
        {
            r[i] = false;
        }
        for (var i = 1;i<k; i++)
        {
            for (var j = 0; j<40; j++)
            {
                if((2*(j+1)%a[i]+a[k]%a[i])%a[i]==0)r[j] = true;
            }
        }
        for (var i = 1; ; i++)
        {
            if (r[i - 1]) continue;
            q = 2*i;
            break;
        }
        return a[k]+q;
    }
    private static void ModPrime(int n)
    {
        var a = new int[n];
        a[0] = 2;
        a[1] = 3;
        a[2] = 5;
        a[3] = 7;
        for (var i = 4; i < n; i++)
        {
            a[i] = NewK(i - 1, a);
        }
        //print(a[n-1]);
    }
    public static int PrimeAll(int n)
    {
        int x = 0;
        switch (n)
        {
            case 1:
                x = 2;
                break;
            case 2:
                x = 3;
                break;
            default:
                var a = 3;
                for (var i = 3; i <= n; i++)
                {
                    for (var k = a+2;; k = k + 2)
                    {
                        if (!PrimeBool(k)) continue;
                        a = k;
                        break;
                    }
                }
                x = a;
                break;
        }
        return x;
    }

    public static bool PrimeBool(int n)
    {
        if (n != 2 && n%2 == 0) return false;
        for (var i = 3; i*i <=n ; i++)
        {
            if (n%i == 0) return false;
        }
        return true;
    }
    private static int NewPrime(int k)
    {
        var count = 1;
        var number = 1;
        a: while (true)
        {
            number += 2;
            for (var i = 3; i * i <= number; i += 2)
            {
                if (number%i == 0) goto a;
            }
            count++;
            if (count == k) break;
        }
        return number;
    }
    private static int ToroPrime(int n)
    {
        var a = new int[n];
        a[0] = 2;
        a[1] = 3;
        var count = 1;
        var number = 3;
        while (true)
        {
            var find = false;
            number += 2;
            for (var i = 1; a[i]*a[i] <= number; i++)
            {
                if (number%a[i] == 0)
                {
                    find =true;
                    break;
                }
            }
            if(find)continue;
            count++;
            a[count] = number;
            if (count == n-1) break;
        }
        return number;
    }
    private static int SoPrime(int n)
    {
        var count = 1;
        var number=1;
        var a = new List<bool> {true};
        a:  while (true)
        {
            number += 2;
            for (var i = 3; i*i <= number; i += 2)
            {
                if (!a[(i - 1)/2]) continue;
                if (number%i != 0) continue;
                a.Add(false);
                goto a;
            }
            count++;
            if(count==n)break;
            a.Add(true);
        }
        return number;
    }

    private static ulong SpecialPrime(int n)
    {
        if (n == 1)return 2;
        if (n == 2) return 3;
        if (n == 3) return 5;
        if (n == 4) return 7;
        if (n == 5) return 11;
        ulong result = 11;
        var all = new List<ulong> {11};
        var maxies = new List<ulong>();
        int count = 5;
        ulong max = 11;
        a: while (count!=n)
        {
            result += 2;
            if (result%3 == 0) goto a;
            if (result%10 == 5) goto a;
            if (result%7 == 0) goto a;
            var length = all.Count;
            for (int i = 0; i < length; i++)
            {
                if (Gcd(all[i], result*210) == 1)
                {
                    if (i + 1 == length)
                    {
                        if (Max/result < all[i])
                        {
                            all.Add(result);
                            maxies.Add(max);
                        }
                        else
                        {
                            all[i] *= result;
                        }
                        max = result;
                        count++;
                    }
                    else if(maxies.Count>=1)
                    {
                        if (maxies[i]*maxies[i] > result)
                        {
                            int l = all.Count - 1;
                            if (Max / result < all[l])
                            {
                                all.Add(result);
                                maxies.Add(max);
                            }
                            else
                            {
                                all[l] *= result;
                            }
                            max = result;
                            count++;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }
        //Debug.Log(all.Count);
        return result;
    }
    private static ulong Gcd(ulong m, ulong n)
    {
        while (true)
        {
            var r = m % n;
            if (r == 0) return n;
            m = n;
            n = r;
        }
    }
}
