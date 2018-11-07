using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;

	// Update is called once per frame
	void Update () {
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
