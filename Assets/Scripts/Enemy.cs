using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] WaveManager manager;
    [SerializeField] int health = 2;
    [SerializeField] float speed = 5;
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] float minDistance = 5;
    [SerializeField] PlayerController player;

    [SerializeField] GameObject deathVFX;

    void Start()
    {
        manager = GetComponentInParent<WaveManager>();
        player = FindObjectOfType<PlayerController>();
    }

    private void Update() 
    {
        if (Vector3.Distance(transform.position, player.gameObject.transform.position) > minDistance)
        {
            transform.position = new Vector3 (Vector3.MoveTowards(transform.position, player.gameObject.transform.position, speed * Time.deltaTime).x, transform.position.y, Vector3.MoveTowards(transform.position, player.gameObject.transform.position, speed * Time.deltaTime).z);
        }

        Vector3 direction = (player.gameObject.transform.position - transform.position);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.GetComponent<Bullet>() != null)
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            manager.SubtractEnemy();
            Destroy(gameObject);
        }
    }
}
