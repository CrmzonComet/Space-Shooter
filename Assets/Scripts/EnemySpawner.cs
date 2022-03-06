using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemiesToSpawn;
    public float spawnRate;
    // Update is called once per frame
    void Update()
    {
        if( Random.Range(0f,100f) < spawnRate)
        {
            Vector3 spawnPosition = this.transform.position;
            spawnPosition.y += Random.Range(-5f, 5f);

            //choose random position in array 
            int randomEnemyPosition = Random.Range(0, enemiesToSpawn.Length);

            //spawn that enemy
            Instantiate(enemiesToSpawn [randomEnemyPosition], spawnPosition, Quaternion.identity);
        }
    }
}
