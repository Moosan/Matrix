using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class GameContoroller : MonoBehaviour
    {
        public GameObject Camera;
        public GameObject[] Colors;
        public int Number;
        public List<List<GameObject>> AllPoll;
        public bool Turn;
        public Vector3 StartPos, EndPos;
        public void Start()
        {
            Make();
            Turn = true;
        }

        public void Update()
        {
            if (!Turn) return;
            if (Input.GetMouseButtonDown(0))
            {
                StartPos = GetPos();
            }
            if (!Input.GetMouseButtonUp(0)) return;
            EndPos = GetPos();
            Play();
        }

        public void Make()
        {
            AllPoll = new List<List<GameObject>>();
            for (var i = 0; i < Number; i++)
            {
                var num = Random.Range(2, 7);
                var polls=new List<GameObject>();
                for (var j = 0; j < num; j++)
                {
                    var obj=(GameObject)Instantiate(Colors[i], new Vector3(j ,0 , -2*i+5), new Quaternion());
                    polls.Add(obj);
                }
                AllPoll.Add(polls);
            }
        }

        public Vector3 GetPos()
        {
            var screenPoint = Input.mousePosition;
            screenPoint.z = 10;
            var v = Camera.GetComponent<Camera>().ScreenToWorldPoint(screenPoint);
            return new Vector3(Mathf.Floor(v.x + 0.5f), 0, Mathf.Floor(v.z + 0.5f));
        }

        public void Play()
        {
            var color = -(int) (StartPos.z - 5)/2;
            var broad = Math.Abs((int) (EndPos.x - StartPos.x));
            var count = AllPoll[color].Count;
        
            for (var i = 0; i < broad; i++)
            {
                Destroy(AllPoll[color][count-i-1]);
            }
            AllPoll.Reverse(1 + (int) StartPos.x, (int) EndPos.x);
            StartPos=new Vector3();
            EndPos=new Vector3();
        }
    }
}
