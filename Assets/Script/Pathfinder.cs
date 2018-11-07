using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
    [SerializeField] WayPoint StartWayPoint, EndwayPoint;
    WayPoint SearchCenter;
    // a dictionary is used to store value,it's a data structure that is used to store values that hv keys
    // an int is a type of key and a variable or an int can be used as a key;
    // dictionar <key , value> = new dcition(this will handle all the strogae)
    bool isRunning = true;
    Dictionary<Vector2Int,WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
   List<WayPoint> path = new List<WayPoint>();
    Vector2Int[] Directions =

    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    public List<WayPoint> GetPath()
    {
        LoadBlocks();
        StartColor();
        EndColor();
        FIndPath();
        CreatPath();
        return path;
    }
   

    private void CreatPath()
    {
        path.Add(EndwayPoint);
        WayPoint previous = EndwayPoint.ExploredFrom;
        while(previous != StartWayPoint)
        {
            path.Add(previous);
            previous = previous.ExploredFrom;
        }
        path.Add(StartWayPoint);
        path.Reverse();
    }

    private void FIndPath()
    {
        queue.Enqueue(StartWayPoint);
        while(queue.Count > 0 && isRunning)
        {
            SearchCenter = queue.Dequeue();
           // print("Searching From :" +SearchCenter);
            HalthIfEndFound();   
            ExploreNeighbours();
            SearchCenter.isExplored = true;

        }
        //print("Finished pathfinding");

    }

    private void HalthIfEndFound()
    {
        if (SearchCenter== EndwayPoint)
        {
           // print("searching from end node , therefore it is stoping");
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning){ return; }
        foreach(Vector2Int direction in Directions)
        {
            Vector2Int NeighbourCoordinate = SearchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(NeighbourCoordinate))
            {
                QueueNewNeighbours(NeighbourCoordinate);
            }
            //  print("Exploring " + ExploringCoordinates);
            //try
            //{
            //    QueueNewNeighbours(NeighbourCoordinate);
            //}
            //catch
            //{
            //    do nothing
            //}
        }
    }

    private void QueueNewNeighbours(Vector2Int NeighbourCoordinate)
    {
        
         WayPoint neighbour = grid[NeighbourCoordinate];
        if (neighbour.isExplored|| queue.Contains(neighbour))
        {
           // do nothing
        }
        else
        {
            //neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            neighbour.ExploredFrom = SearchCenter;
        }
    }

    private void EndColor()
    {
      //  EndwayPoint.SetTopColor(Color.red);
    }

    private void StartColor()
    {
     
        //    StartWayPoint.SetTopColor(Color.green);
    }

   
    private void LoadBlocks()
    {
        // findobject of type returns an array of the object that was found
        // and object is anything that is in the unity editor.
        var wayPoints = FindObjectsOfType<WayPoint>();

        foreach(WayPoint waypoint in wayPoints)
        {
            var gridPos = waypoint.GetGridPos();
           
            //Contains key check if the same key is contained in the dictionary
            if (grid.ContainsKey(gridPos))
            {
               // Debug.LogWarning("skipping an overlap " + waypoint);
               // print(" skipping an overlap"+waypoint);
            }
            else
            {
                grid.Add(gridPos , waypoint);
               
            }
        }
       
       // print(grid.Count);

    }

}
