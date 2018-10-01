using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class Maxsoinnsuu : MonoBehaviour
    {
        public int X;
        // Use this for initialization
        public void Start ()
        {
            Debug.Log(MaxSoinsu(X));
        }
	
        // Update is called once per frame
        public void Update () {
	
        }
        public static int MaxSoinsu(int x)
        {
            var a = 0;
            if (x == 0)
            {
                return 0;
            }
            if (x%2 == 0)
            {
                for (var i = 1; x%2 == 0; i++)
                {
                    x = x/2;
                }
                a = 2;
            }
            for (int i = 3; x != 1; i = i + 2)
            {
                for (int j = 1; x%i == 0; j++)
                {
                    x = x/i;
                }
                a = i;
            }
            return a;
        }
    }
}
