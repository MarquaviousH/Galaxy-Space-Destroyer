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
        // Spawn the Enemies and power-ips based on an interval
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
        // Generate random x and y positions for spawn locations 
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomY = Random.Range(2, ySpawnRange);
        
        // Generate random index to spawn the different types of enemies
        int randomIndex = Random.Range(0,enemies.Length);

        // Set the random spawn position 
        Vector3 spawnPos = new Vector3(randomX, randomY, zSpawnRange);

        // Create the new enemies in the play area
        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    //Spawn power-ups
    void SpawnPowerUps()
    {
        // Generate random x and y positions for spawn locations 
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomY = Random.Range(2, ySpawnRange);

        // Generate random index to spawn the different types of power-ups
        int randomIndex = Random.Range(0, powerUp.Length);

        // Set the a random spawn position 
        Vector3 spawnPos = new Vector3(randomX, randomY, zSpawnRange);

        // Create the new power-ups in the play area
        Instantiate(powerUp[randomIndex], spawnPos, powerUp[randomIndex].gameObject.transform.rotation);
    }
}
