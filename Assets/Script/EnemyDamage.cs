using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] int hitPoints = 10;
    [SerializeField] Collider collisionMesh;
	// Use this for initialization
	void Start () {
       
    }
	
	private void OnParticleCollision(GameObject other)
    {
        ProcessHits();
        if (hitPoints <= 1)
        {
            killenemy();
        }
      
    }

    

    public void ProcessHits()
    {
        hitPoints = hitPoints - 1;
        print("current hitpoints is " + hitPoints);

    }
    private void killenemy()
    {
        Destroy(gameObject, 0.5f);
    }

}
