using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] List<WayPoint> path;
	void Start()
    {
        StartCoroutine(PrintAllWayPoints());
        PrintAllWayPoints();
    }

    IEnumerator PrintAllWayPoints()
    {
        print("Staring Parols");
        foreach (WayPoint waypoint in path)
        {
            transform.position = waypoint.transform.position;

            print("Visiting "+ waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Parols Ended");
    }
}
