using System.Collections.Generic;
using UnityEngine;

public class Build 
{

    private Dictionary<Point, List<Point>> _adjacencyList = new();

    private const int CONNECT_SIZE = 1;

    public void AddPoint(Vector2Int position)
    {
        var point = new Point(position);

        if (!TryGetPoint(position, out Point hasPoint ))
        {
            _adjacencyList.Add(point, new List<Point>());
        }
    }

    public void RemovePoint(Vector2Int position)
    {
        if (TryGetPoint(position, out Point removablePoint))
        {
            var neighbors = _adjacencyList[removablePoint];
            
            foreach (var point in neighbors)
                _adjacencyList[point].Remove(removablePoint);

            _adjacencyList.Remove(removablePoint);
        }
    }

    public void AddConnection(Vector2Int pos1, Vector2Int pos2)
    {
        var distance = Vector2Int.Distance(pos1, pos2);
        
        if (distance != CONNECT_SIZE) return;
        if (!TryGetPoint(pos1, out Point point1)) return;
        if(!TryGetPoint(pos2, out Point point2)) return;
        
        _adjacencyList[point1].Add(point2);
        _adjacencyList[point2].Add(point1);
    }

    public void RemoveConnection(Vector2Int pos1, Vector2Int pos2)
    {
        if (!TryGetPoint(pos1, out Point point1)) return;
        if(!TryGetPoint(pos2, out Point point2)) return;
        
        foreach (var point in _adjacencyList[point1])
        {
            if (point != point2) continue;
            
            _adjacencyList[point1].Remove(point2);
            _adjacencyList[point2].Remove(point1);
        }
    }
    
    public Point[] GetNeighbors(Vector2Int pos)
    {
        if (TryGetPoint(pos, out Point point))
        {
            return _adjacencyList[point].ToArray();
        }
        return null;
    }
    
    private bool TryGetPoint(Vector2Int key, out Point point)
    {
        foreach (var item in _adjacencyList)
        {
            if (item.Key.position != key)
                continue;

            point = item.Key;
            return true;
        }
        point = null;
        return false;
    }
}
