using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
    [SerializeField] WayPoint StartWayPoint, EndwayPoint;
    Dictionary<Vector2Int,WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
	// Use this for initialization
	void Start () {
        LoadBlocks();
        startColor();
        endColor();
	}

    private void endColor()
    {
        EndwayPoint.SetTopColor(Color.red);
    }

    private void startColor()
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
        print(grid.Count);

    }

}
