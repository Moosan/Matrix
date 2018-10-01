using UnityEngine;
using System.Collections;

public class trans : MonoBehaviour
{
    public static int a=2, b=3;
	// Use this for initialization
	void Start ()
	{
	    t(a, b);
	print(a+"/"+b);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void t(int x, int y)
    {
        a = y;
        b = x;
    }
}
