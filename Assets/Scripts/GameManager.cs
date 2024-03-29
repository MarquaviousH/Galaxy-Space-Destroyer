using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    //Declare Variables
    public List<GameObject> enemies;
    public List<GameObject> powerUp;
    private float xSpawnRange = 3.5f;
    private float ySpawnRange = 4.5f;
    private float zSpawnRange = 21.41f;
    private float spawnRate = 2.5f;
    private int score;
    public int lifeCount;
    private int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeCounterText;
    public TextMeshProUGUI highScoreText;
    public static GameManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        //StartCoroutine(SpawnPowerUps()); Was going to implement this with features but has been cut out due to time

        score = 0;
        UpdateScore(score);

        lifeCount = 3;
        UpdateExtraLifeCounter(lifeCount);

        UpdateHighScore(highScore);


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
            yield return new WaitForSeconds(spawnRate + 15);

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

    //Update the score as the player is playing 
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        //Update the high score as the player is playing
        UpdateHighScore(score);
    }

    //Update the extra life as the player is playing
    public void UpdateExtraLifeCounter(int newLifeCount)
    {
        lifeCount = newLifeCount;
        lifeCounterText.text = "Extra Lives: " + lifeCount;
    }

    //Update the high score as the player is playing
    public void UpdateHighScore(int newHighScore)
    {

        //If the current high score is lower than the new one, set the new one as the high score
        if(highScore <= newHighScore)
        {
            highScore = newHighScore;
            highScoreText.text = "High Score: " + highScore;
        }
    }

    //When this load, dont destory the instance of this class
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    //Create a sava data class to save the high score
    [System.Serializable]
    class SaveData
    {
        public int highscore;
    }

    //Save the highest score to a json file
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highscore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //Load the high score from the json file
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highscore;
        }
    }

}
