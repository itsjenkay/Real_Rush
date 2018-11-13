using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] int hitPoints = 10;
    [SerializeField] Collider collisionMesh;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathPArticlePrefab;
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
        //print("current hitpoints is " + hitPoints);
        hitParticlePrefab.Play();
    }
    private void killenemy()
    {
        var vfx = Instantiate(deathPArticlePrefab, transform.position, Quaternion.identity);
        Destroy(vfx.gameObject, vfx.main.duration);
        vfx.Play();
        Destroy(gameObject, 0.5f);
    }


}
