using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
  [SerializeField] List<WayPoint> path;
	void Start()
    {   
        // A string function naming the active coroutine

        //StartCoroutine(PrintAllWayPoints());
        //PrintAllWayPoints();

    }
    

    //The IEnumerator variable used earlier to create the coroutine
    //The Coroutine to stop the manually created Coroutine
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
