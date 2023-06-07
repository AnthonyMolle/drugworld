using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] ParticleSystem particlePrefab;

    private void OnCollisionEnter(Collision other) 
    {
        //make an enemy check once the enemy is in place
        Instantiate(particlePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
