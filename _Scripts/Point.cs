
using UnityEngine;

public class Point
{
    public Vector2Int position { get; private set; }

    public Point(Vector2Int position)
    {
        this.position = position;
    }
}
