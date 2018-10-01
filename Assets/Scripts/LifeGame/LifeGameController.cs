using UnityEngine;
using Random = UnityEngine.Random;

public class LifeGameController : MonoBehaviour
{
    public GameObject Life;
    public GameObject Parent;
    public Material AliveMatelial;
    public Material DeadMatelial;
    public int X, Y, Z;
    public float Width;
    private Life[][][] _world;
    private int[][][] _nextLife;
    private GameObject[][][] _realWorld;
    private Vector3[] _arounds;
    public int Depopu;
    public int Crouded;
    //private int _generation;
    private float _time;
    public float ChangeTime;
    public float Opacity;
    public bool AroundSmall;
    public GameObject GameController;
	public void Start ()
	{
	    _time = 0;
	    //_generation = 0;
		_world=new Life[X][][];
        _nextLife=new int[X][][];
        _realWorld=new GameObject[X][][];
	    for (var i = 0; i < X; i++)
	    {
	        var parent = Instantiate(Parent, transform.position+new Vector3(i, Y, Z), new Quaternion());
	        parent.transform.parent = GameController.transform;
            _world[i]=new Life[Y][];
            _nextLife[i]=new int[Y][];
            _realWorld[i]=new GameObject[Y][];
	        for(var j = 0; j < Y;j++)
	        {
	            _world[i][j]=new Life[Z];
                _nextLife[i][j]=new int[Z];
                _realWorld[i][j]=new GameObject[Z];
	            for (var k = 0; k < Z; k++)
	            {
	                _nextLife[i][j][k] = 0;
	                var obj=_realWorld[i][j][k] = Instantiate(Life, transform.position+new Vector3(i, j, k), new Quaternion());
                    obj.transform.parent = parent.transform;
                    obj.GetComponent<Renderer>().material.color = new Vector4((float)i / X, (float)j / Y, (float)k / Z, Opacity);
                    //if (i == 0)
                    //{
                    _world[i][j][k] = new Life(Random.value > Width);
                    //}
                    //_world[i][j][k] = new Life(false);
	                obj.GetComponent<Renderer>().enabled = _world[i][j][k].Alive;
                }
	        }
	    }
	    var count = 0;
	    if (AroundSmall)
	    {
	        _arounds=new[]
	        {
	            new Vector3(1,0,0),
                new Vector3(0,1,0),
                new Vector3(0,0,1),
                new Vector3(-1,0,0),
                new Vector3(0,-1,0),
                new Vector3(0,0,-1),
            };
            return;
	    }
        _arounds=new Vector3[26];
	    for (var i = -1; i <= 1; i++)
	    {
	        for (var j = -1; j <= 1; j++)
	        {
	            for (var k = -1; k <= 1; k++)
	            {
	                if(i==0&&j==0&&k==0)continue;
                    _arounds[count]=new Vector3(i,j,k);
	                count++;
	            }
	        }
	    }
	}
	public void Update ()
	{
	    _time += Time.deltaTime;
	    if (!(_time >= ChangeTime)) return;
	    MakeNextLife();
	    ChangeGeneration();
	    _time = 0;
	}

    public void MakeNextLife()
    {
        for (var i = 0; i < X; i++)
        {
            for (var j = 0; j < Y; j++)
            {
                for (var k = 0; k < Z; k++)
                {
                    var lifeCount = LifeCount(i,j,k);
                    var alive = _world[i][j][k].Alive;
                    if (alive)
                    {
                        if (lifeCount >= Crouded || lifeCount <= Depopu) _nextLife[i][j][k] = 2;
                    }
                    else if (lifeCount < Crouded && lifeCount > Depopu) _nextLife[i][j][k] = 1;
                    else _nextLife[i][j][k] = 0;
                }
            }
        }
    }

    public void ChangeGeneration()
    {
        for (var i = 0; i < X; i++)
        {
            for (var j = 0; j < Y; j++)
            {
                for (var k = 0; k < Z; k++)
                {
                    Act(_nextLife[i][j][k],i,j,k);
                }
            }
        }
        //_generation++;
        //Debug.Log("第"+_generation+"世代");
    }

    public int LifeCount(int i,int j,int k)
    {
        var count = 0;
        foreach (var a in _arounds)
        {
            var x = i + (int) a.x;
            var y = j + (int) a.y;
            var z = k + (int) a.z;
            if (x == -1) x = X - 1;
            if (x == X) x = 0;
            if (y == -1) y = Y - 1;
            if (y == Y) y = 0;
            if (z == -1) z = Z - 1;
            if (z == Z) z = 0;
            if (_world[x][y][z].Alive) count++;
            /*if (x >= 0 && x < X)
            {
                if (y >= 0 && y < Y)
                {
                    if (z >= 0 && z < Z)
                    {
                        if (_world[x][y][z].Alive) count++;
                    }
                }
            }*/
        }
        return count;
    }

    public void ReBorn(int i,int j,int k)
    {
        _realWorld[i][j][k].GetComponent<Renderer>().enabled = true;
        _world[i][j][k].Alive = true;
    }
    public void Kill(int i, int j, int k)
    {
        _realWorld[i][j][k].GetComponent<Renderer>().enabled=false;
        _world[i][j][k].Alive = false;
    }

    public void Act(int next, int i, int j, int k)
    {
        switch (next)
        {
            case 1:
                ReBorn(i,j,k);
                break;
            case 2:
                Kill(i,j,k);
                break;
            default:
                return;
        }
    }
}
public class Life
{
    public bool Alive;

    public Life(bool alive)
    {
        Alive = alive;
    }
}
