﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {
    public bool isExplored = false;
    public WayPoint ExploredFrom;
    const int gridSize = 10;
    Vector2Int gridPos;
    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
              Mathf.RoundToInt(transform.position.x / gridSize) ,
              Mathf.RoundToInt(transform.position.z / gridSize) 
            );

    }
   public  void OnMouseOver()
    {
        print("hello");
    }
    public void SetTopColor(Color color)
    {
        MeshRenderer topColor=  transform.Find("top").GetComponent<MeshRenderer>();
        topColor.material.color = color;
    }

    
    
}
