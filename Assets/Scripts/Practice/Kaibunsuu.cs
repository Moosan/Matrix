using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class Kaibunsuu : MonoBehaviour
{
    public int x;
	// Use this for initialization
	void Start ()
	{
	    Max(x);
	}
	void Update () {}
    public static bool kaibunBool(int x)
    {
        int A = 0;
        for (int i = 1; x >= i; i = i*10)
        {
            A++;
        }
        int[] B=new int[A];
        int[] C=new int[A];
        for (int i = 0; i < A; i++)
        {
            B[i] = x/tenPower(A-1-i);
            C[A - i - 1] = x/tenPower(A-1-i);
            x = x%tenPower(A -1- i);
        }
        for (int i = 0; i < A; i++)
        {
            if (B[i] != C[i])
            {
                return false;
            }
        }
        return true;
    }
    public static int tenPower(int A)
    {
        if (A == 1)
        {
            return 10;
        }
        else if (A == 0)
        {
            return 1;
        }
        return 10*tenPower(A - 1);
    }

    public static void Max(int x)
    {
        int A = 0;
        int a=0, b = 0;
        for (int i = tenPower(x - 1); i < tenPower(x); i++)
        {
            for (int j = i; j < tenPower(x); j++)
            {
                if (kaibunBool(i*j))
                {
                    if (i*j > A)
                    {
                        A = i*j;
                        a = i;
                        b = j;
                    }
                }
            }
        }
        Debug.Log(a+"*"+b);
        Debug.Log(A);
    }
}
