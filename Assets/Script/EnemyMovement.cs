﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] float movementPeriod = 0.5f;
    [SerializeField] ParticleSystem destroyFriendly;
	void Start()
    {
        // A string function naming the active coroutine

        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var  path = pathfinder.GetPath();
        StartCoroutine(PrintAllWayPoints(path));
        //PrintAllWayPoints();

    }


    //the ienumerator variable used earlier to create the coroutine
    //the coroutine to stop the manually created coroutine
    IEnumerator PrintAllWayPoints(List<WayPoint> path)
    {
       // print("staring parols");
        foreach (WayPoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
          //  print("visiting " + waypoint.name);
            yield return new WaitForSeconds(movementPeriod);
        }

        destroyFriendlyBase();
    }

    private void destroyFriendlyBase()
    {
        var vfx = Instantiate(destroyFriendly, transform.position, Quaternion.identity);
        Destroy(vfx.gameObject, vfx.main.duration);
        vfx.Play();
        Destroy(gameObject);
    }
}
