using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    
    [SerializeField] Door[] doors;
    [SerializeField] Transform[] spawns;

    private bool waveActive = false;
    private bool waveComplete = false;

    private int enemyCount;

    private void Start() 
    {
        enemyCount = spawns.Length;
    }


    public void SubtractEnemy()
    {
        enemyCount -= 1;
        if (enemyCount <= 0)
        {
            EndWave();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            if (!waveActive && !waveComplete)
            {
                StartWave();
            }    
        }    
    }

    private void StartWave()
    {
        Debug.Log("started wave");

        foreach(Door door in doors)
        {
            door.Close();
        }

        foreach(Transform spawnPoint in spawns)
        {
            var enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemy.transform.SetParent(gameObject.transform);
        }

        waveActive = true;
    }

    private void EndWave()
    {
        foreach(Door door in doors)
        {
            door.Open();
        }

        waveComplete = true;
    }
}
