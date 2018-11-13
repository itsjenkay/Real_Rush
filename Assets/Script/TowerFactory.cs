using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;
    Queue<Tower> towerqueue = new Queue<Tower>();
    //int numTowers = 0;

    public void AddTower(WayPoint basewaypoint)
    {
        int numTowers = towerqueue.Count;
        if (numTowers<towerLimit)
        {
            InstantiateNewTower(basewaypoint);
        }
        else
        {
            MoveExistingTowers(basewaypoint);
        }
    }

    private void InstantiateNewTower(WayPoint basewaypoint)
    {
       var newTowers =  Instantiate(towerPrefab, basewaypoint.transform.position, Quaternion.identity);
        newTowers.transform.parent = towerParentTransform;
        basewaypoint.isPlacable = false;

        newTowers.basewaypoint = basewaypoint;
        basewaypoint.isPlacable = false;
        towerqueue.Enqueue(newTowers);
        //  numTowers++;
    }
    private  void MoveExistingTowers(WayPoint newBaseWayPoint)
    {
        var oldTowers = towerqueue.Dequeue();
        oldTowers.basewaypoint.isPlacable = true;
        newBaseWayPoint.isPlacable = false;

        oldTowers.basewaypoint = newBaseWayPoint;
        oldTowers.transform.position = newBaseWayPoint.transform.position;
        towerqueue.Enqueue(oldTowers);
    }

}
