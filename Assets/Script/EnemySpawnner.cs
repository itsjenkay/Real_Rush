using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour {
    [Range(0.1f,120f)]  [SerializeField] float secondsBetweenSpawans = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    // Use this for initialization
    void Start () {
        
        StartCoroutine(EnemySpawing());
    }

    IEnumerator EnemySpawing()
    {
        while (true)
        {
            var newEnemy=  Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawans);
         //   print("spawining");


        }

    }
}
