using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humika : MonoBehaviour {
    public int Count;
	// Use this for initialization
	void Start () {
        if (Count == 1)
        {
            Debug.Log("1個目の素数は2だよ");
        }
        else
        {
            int Number = 3;
            for (int j = 2; j <= Count; j++)
            {
                bool sosuudayo = true;
                for (int i = 3; i < Number; i += 2)
                {
                    if (Number % i == 0)
                    {
                        sosuudayo = false;
                        break;
                    }
                }
                if (!sosuudayo)
                {
                    j--;
                }
                Number += 2;
            }
            Debug.Log(Count + "番目の素数は、多分、" + (Number -2) + "だよ");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
