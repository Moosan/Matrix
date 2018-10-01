using System.Collections.Generic;
using System.Linq;

public class Cell
{
    private readonly Cell[] _arounds;
    private static List<Cell> _cells;
    private static List<int[]> _cellsPos;
    private static List<int[]> World;
    private readonly int[] _pos;
    private bool _isActive;
    private static int[][] _aroundsInt;
    private int _enviroment;

    private static int _depopu;
    public static int Depopu
    {
        set { _depopu = value; }
    }

    private static int _crouded;
    public static int Crouded
    {
        set { _crouded = value; }
    }

    public Cell(int i, int j, int k, bool isActive)
    {
        if (_cells.Count < 1)
        {
            _cells=new List<Cell>();
            _cellsPos=new List<int[]>();
            World=new List<int[]>();
        }
        _pos = new[]
        {
            i, j, k
        };
        _cellsPos.Add(_pos);
        _isActive = isActive;
        _cells.Add(this);
        _arounds = new Cell[26];
        if (!_isActive) return;
        World.Add(_pos);
        _arounds = MakeArounds();
    }

    private Cell[] MakeArounds()
    {
        var count = 0;
        var result = new Cell[26];
        if (_aroundsInt.Length != 26) MakeArray();
        foreach (var around in _aroundsInt)
        {
            var i1 = around[0] + _pos[0];
            var j1 = around[1] + _pos[1];
            var k1 = around[2] + _pos[2];
            var pos=new [] {i1,j1,k1};
            var exist = _cellsPos.Any(posi => posi == pos);
            if (exist)
            {
                foreach (var cell in _cells)
                {
                    if (pos != cell._pos) continue;
                    result[count] = cell;
                    break;
                }
            }
            else result[count] = new Cell(i1, j1, k1, false);
            count++;
        }
        return result;
    }

    private static void MakeArray()
    {
        var count = 0;
        _aroundsInt = new int[26][];
        for (var i = -1; i <= 1; i++)
        {
            for (var j = -1; j <= 1; j++)
            {
                for (var k = -1; k <= 1; k++)
                {
                    if (i == j && j == k && k == 0) continue;
                    _aroundsInt[count] = new[] {i, j, k};
                    count++;
                }
            }
        }
    }
    
    private void LookEnviroment()
    {
        _enviroment=_arounds.Count(around => around._isActive);
    }

    private void Dead()
    {
        var env = _enviroment;
        if (!_isActive || env > _depopu || env < _crouded) return;
        _isActive = false;
        World.Remove(_pos);
    }

    private void Born()
    {
        var env = _enviroment;
        if (_isActive || env <= _depopu || env >= _crouded) return;
        _isActive = true;
        World.Add(_pos);
    }

    private void Action()
    {
        if(_isActive)Dead();
        else Born();
    }

    private static void SearchAround()
    {
        foreach (var cell in _cells)
        {
            cell.LookEnviroment();
        }
    }

    private static void NextAction()
    {
        foreach (var cell in _cells)
        {
            cell.Action();
        }
    }

    public void GenerationChange()
    {
        SearchAround();
        NextAction();
    }

    public static List<int[]> GetAWorld()
    {
        return World;
    }
}