using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]

public class CubeEditor : MonoBehaviour {
    WayPoint wayPoint;
  
    void Awake()
    {
        wayPoint = GetComponent<WayPoint>();
    }
    void Update()
    {
        SanpToGrid();
        UpdateLabel();
    }
    private void SanpToGrid()
    {
        int gridSize = wayPoint.GetGridSize();
        transform.position = new Vector3(wayPoint.GetGridPos().x, 0f, wayPoint.GetGridPos().y);
    }
    private void UpdateLabel()
    {
        TextMesh textMesh= GetComponentInChildren<TextMesh>();
        int gridSize = wayPoint.GetGridSize();
        string labelText = wayPoint.GetGridPos().x / gridSize + "," + wayPoint.GetGridPos().y/ gridSize;
        textMesh.text = labelText;
        gameObject.name = "cube" + labelText;
    }
}
