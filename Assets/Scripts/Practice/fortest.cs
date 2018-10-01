using UnityEngine;
using System.Collections;

public class fortest : MonoBehaviour
{
    public int n;

	void Start ()
	{
	    int prime=0;
        
	    for (int i = 3; i*i <=n ; i+=2)
	    {
	        if (n%i == 0)
	        {
	            prime = 1;
                break;
	        }
	    }
	    if (prime == 0)
	    {
	        print("素数");
	    }
	    else
	    {
	        print("素数ではない");
	    }
	}

}
