using UnityEngine;

namespace Assets.Scripts
{
    public class Rensyuu : MonoBehaviour
    {
        public int InputNumber;
        void Start()
        {
            for (int i = 1; i <= InputNumber; i++)
            {
                if (i % 3 == 0 || i % 10 == 3)
                {
                    Debug.Log(i + "で僕は馬鹿になる");
                    continue;
                }
                bool baka = false;
                for (int n = 0;i>Pow(10,n) ; n++)
                {
                    if (i/Pow(10, n) == 3)
                    {
                        Debug.Log(i+"で僕は馬鹿になる");
                        baka = true;
                        break;
                    }
                }
                if(baka)continue;
                Debug.Log(i+"で僕はいつもどおり");
            }
        }

        public int Pow(int a, int b)
        {
            if (b == 0)
            {
                return 1;
            }
            else
            {
                return Pow(a, b - 1)*a;
            }
        }
    }
}
