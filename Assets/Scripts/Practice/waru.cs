using UnityEngine;
using System.Collections;

public class waru : MonoBehaviour {
    public static int[] pr = new int[] { 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 91, 97, 103 };
    public int n;
	void Start () {
        w(n);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public static void w(int n)
    {
        for(int i = 0; i < pr.Length; i++)
        {
            print(n+"%"+pr[i]+"="+n % pr[i]+"//"+(pr[i]-n%pr[i]));
        }
    }
}
