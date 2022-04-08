using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Declare Variables
    public GameObject[] enemies;
    public GameObject[] powerUp;
    private  float xSpawnRange = 3.5f;
    private float ySpawnRange = 4.5f;
    private float zSpawnRange = 21.41f;
    private float startDelay = 3.0f;
    private float enemySpawnTime = 2.0f;
    private float powerUpSpawnTime = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerUps", startDelay, powerUpSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn enemies 
    void SpawnEnemies()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomY = Random.Range(2, ySpawnRange);
        int randomIndex = Random.Range(0,enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, randomY, zSpawnRange);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerUps()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomY = Random.Range(2, ySpawnRange);
        int randomIndex = Random.Range(0, powerUp.Length);

        Vector3 spawnPos = new Vector3(randomX, randomY, zSpawnRange);

        Instantiate(powerUp[randomIndex], spawnPos, powerUp[randomIndex].gameObject.transform.rotation);
    }
}
