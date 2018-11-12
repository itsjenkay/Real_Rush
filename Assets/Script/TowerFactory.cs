using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    //int numTowers = 0;

    public void AddTower(WayPoint basewaypoint)
    {
        var towers = FindObjectsOfType<Tower>();
        var numTowers = towers.Length;
        if (numTowers<towerLimit)
        {
            InstantiateNewTower(basewaypoint);
        }
        else
        {
            MoveExistingTowers();
        }
    }

    private static void MoveExistingTowers()
    {
        Debug.Log("Move existing towers");
    }

    private void InstantiateNewTower(WayPoint basewaypoint)
    {
        Instantiate(towerPrefab, basewaypoint.transform.position, Quaternion.identity);
        basewaypoint.isPlacable = false;
      //  numTowers++;
    }
}
