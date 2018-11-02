using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
    [SerializeField] WayPoint StartWayPoint, EndwayPoint;

    // a dictionary is used to store value,it's a data structure that is used to store values that hv keys
    // an int is a type of key and a variable or an int can be used as a key;
    // dictionar <key , value> = new dcition(this will handle all the strogae)
    bool isRunning = true;
    Dictionary<Vector2Int,WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    Vector2Int[] Directions =

    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
	// Use this for initialization
	void Start () {
        LoadBlocks();
        StartColor();
        EndColor();
        ExploreNeighbours();
        FIndPath();
	}

    private void FIndPath()
    {
        queue.Enqueue(StartWayPoint);
        while(queue.Count>0){
            var SearchCenter = queue.Dequeue();
            print("this is the first search"+SearchCenter);
            HalthIfEndFound(SearchCenter);            
        }
    }

    private void HalthIfEndFound(WayPoint searchCenter)
    {
        if (EndwayPoint == searchCenter)
        {
            print("searching from end, therefore it is stoping");
            isRunning = false;

        }
    }

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in Directions)
        {
            Vector2Int ExploringCoordinates = StartWayPoint.GetGridPos() + direction;
          //  print("Exploring " + ExploringCoordinates);
            try
            {
                grid[ExploringCoordinates].SetTopColor(Color.cyan);
            }
            catch
            {
                // do nothing
            }
        }
    }

    private void EndColor()
    {
        EndwayPoint.SetTopColor(Color.red);
    }

    private void StartColor()
    {
     
            StartWayPoint.SetTopColor(Color.green);
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
                print(" skipping an overlap"+waypoint);
            }
            else
            {
                grid.Add(gridPos , waypoint);
               
            }
        }
       
       // print(grid.Count);

    }

}
