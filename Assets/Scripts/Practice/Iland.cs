using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iland : MonoBehaviour
{
    public int L;
    public float Witdth;
    public int[][] X;
    public GameObject W, B;
    public static int[][] A= {
            new[] {0,1},new[] {1,0},new[] {0,-1},new[] {-1,0}
        };
    private void Start() {
        X=new int[L][];
        for (var i = 0; i < L; i++)
        {
            X[i]=new int[L];
            for (var j = 0; j < L; j++)
            {
                if (i == 0 || j == 0 || i == L - 1 || j == L - 1)
                {
                    X[i][j] = 0;
                    continue;
                }
                X[i][j] = (int)Random.Range(0, Witdth);
                /*if ( j+i >= L/2&&i+j<=3*L/2&&j-i<=L/2&&j-i>=-L/2) X[i][j] = (int)Random.Range(0, Witdth);
                else X[i][j] = 0;*/
            }
        }
        var a = new Elem[X.Length][];
        for(var i = 0; i < X.Length; i++)
        {
            a[i] = new Elem[X[i].Length];
            for(var j = 0; j < X[i].Length; j++)
            {
                a[i][j] = new Elem(X[i][j]);
            }
        }
        Debug.Log(Cou(a));
        for(var i = 0; i < X.Length; i++)
        {
            for(var j = 0; j < X[i].Length; j++)
            {
                var obj = X[i][j] == 0 ? W : B;
                Instantiate(obj, new Vector3(j - L/2, -i + L/2, 0), new Quaternion());
            }
        }
    }
    public int Cou(Elem[][] a)
    {
        var cou = 0;
        for(var i = 0; i < a.Length; i++)
        {
            for(var j = 0; j < a[i].Length; j++)
            {
                var x = a[i][j];
                if (x.IsL||x.IsM) continue;
                if (!IsLo(i, j, a)) continue;
                Debug.Log(i + ":" + j);
                cou++;
            }
        }
        return cou;
    }
    public bool IsLo(int i,int j,Elem[][] a)
    {
        var isLo = true;
        a[i][j].IsL = true;
        var h = a.Length-1;
        var w = a[i].Length-1;
        foreach(var n in A)
        {
            var i1 = i + n[0];
            var j1 = j + n[1];
            if (0 <= i1 && i1 <= h && 0 <= j1 && j1 <= w)
            {
                var next = a[i1][j1];
                if (next.IsM) continue;
                if (next.IsL) continue;
                if (IsLo(i + n[0], j + n[1], a)) continue;
            }
            isLo=false;
        }
        return isLo;
    }
}
public class Elem
{
    public bool IsM;
    public bool IsL;
    public Elem(int i)
    {
        IsM = i != 0;
        IsL = false;
    }
}
