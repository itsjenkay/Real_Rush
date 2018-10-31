using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] List<Blocks> path;
	void Start()
    {
        PrintAllWayPoints();
    }

    private void PrintAllWayPoints()
    {
        foreach (Blocks waypoint in path)
        {
            print(waypoint.name);
        }
    }
}
