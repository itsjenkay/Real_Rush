using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;
    public WayPoint basewaypoint;

    Transform targetEnemy;


    // Update is called once per frame
    void Update ()
    {
        setTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            fireAtEnemy();
        }
        else
        {
            shoot(false);
        }

    }

    private void setTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0)
        {
            return;
        }
        Transform closetEnemy = sceneEnemies[0].transform;
        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closetEnemy = GetCloset(closetEnemy, testEnemy.transform);
        }
        targetEnemy= closetEnemy;
    }

    private Transform GetCloset(Transform transformA, Transform transformB)
    {
        var distanceToA = Vector3.Distance(transform.position, transformA.position);
        var distanceToB = Vector3.Distance(transform.position, transformB.position);
        if (distanceToA < distanceToB)
        {
            return transformA;
        }
        return transformB;
    }

    private void fireAtEnemy()
    {
        var enemyDistance = targetEnemy.transform.position;
        var towerDistance = gameObject.transform.position;
        float distanceToEnemy = Vector3.Distance(enemyDistance, towerDistance);
        if (distanceToEnemy <= attackRange)
        {
            shoot(true);
        }
        else
        {
            shoot(false);
        }
    }

    private void shoot(bool activate)
    {
        var particleEmission = projectileParticle.emission;
        particleEmission.enabled = activate;
    }
}
