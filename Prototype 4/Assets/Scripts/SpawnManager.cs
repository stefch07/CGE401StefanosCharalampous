using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public TMP_Text waveText; // Text for displaying current wave
    public TMP_Text winText; // Text for displaying win message
    private float spawnRange = 9f;
    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup(1);
        waveText.text = "Wave: " + waveNumber; // Initialize wave number display
        winText.gameObject.SetActive(false); // Ensure win text is hidden at the start
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (waveNumber > 10) // Win condition
        {
            DisplayWinMessage();
        }
        else if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup(1);
            waveText.text = "Wave: " + waveNumber; // Update wave number display
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    private void DisplayWinMessage()
    {
        winText.gameObject.SetActive(true); // Show the win text
        Time.timeScale = 0; // Pause the game
        Debug.Log("You Win! Press R to Restart!");

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1; // Resume the game before restarting
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the scene
        }
    }
}