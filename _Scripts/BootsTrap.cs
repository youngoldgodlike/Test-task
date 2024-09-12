using UnityEngine;

public class BootsTrapExample : MonoBehaviour
{
   
   [SerializeField] private Vector2Int key;
   [SerializeField] private Vector2Int key1;

   private Build _build;
  
   private void Start()
   {
       _build = new Build();

       _build.AddPoint(key);
       _build.AddPoint(key1);
       _build.AddConnection(key, key1);
       
       LogConnect(key);
       LogConnect(key1);
   }
   
   
   private void LogConnect(Vector2Int key)
   {
      foreach (var point in _build.GetNeighbors(key))
      {
         Debug.Log(point.position);
      }
   }
}
