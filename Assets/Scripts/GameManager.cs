using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> powerUp;
    private float xSpawnRange = 3.5f;
    private float ySpawnRange = 4.5f;
    private float zSpawnRange = 21.41f;
    private float spawnRate = 4.0f;
    private int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());

        score = 0;
        UpdateScore(10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);

            // Generate random x and y positions for spawn locations 
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            float randomY = Random.Range(2, ySpawnRange);

            // Generate random index to spawn the different types of enemies
            int randomIndex = Random.Range(0, enemies.Count);

            // Set the random spawn position 
            Vector3 spawnPos = new Vector3(randomX, randomY, zSpawnRange);

            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    IEnumerator SpawnPowerUps()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);

            // Generate random x and y positions for spawn locations
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            float randomY = Random.Range(2, ySpawnRange);

            // Generate random index to spawn the different types of power-ups
            int randomIndex = Random.Range(0, powerUp.Count);

            // Set the a random spawn position 
            Vector3 spawnPos = new Vector3(randomX, randomY, zSpawnRange);

            // Create the new power-ups in the play area
            Instantiate(powerUp[randomIndex], spawnPos, powerUp[randomIndex].gameObject.transform.rotation);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
