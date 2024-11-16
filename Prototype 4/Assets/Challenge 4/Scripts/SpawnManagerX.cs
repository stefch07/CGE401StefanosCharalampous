/*
 * Stefanos Charalampous
 * SpawnManagerX.cs
 * Assignment 7
 * Manages spawning, win/loss conditions, and restarting the game.
 */

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    public TMP_Text waveText; // Text displaying the current wave
    public TMP_Text lossText; // Text displayed on loss
    public TMP_Text winText; // Text displayed on win

    public int waveCount = 1;
    public float enemySpeed = 50f; // Base speed of enemies

    private float spawnRangeX = 10f;
    private float spawnZMin = 15f; // Minimum spawn Z
    private float spawnZMax = 25f; // Maximum spawn Z

    public GameObject player; // Reference to the player

    private bool isGameOver = false; // Tracks if the game is over

    void Start()
    {
        waveText.text = "Wave: " + waveCount;
        lossText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);

        SpawnEnemyWave(waveCount);
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 && waveCount <= 10)
        {
            waveCount++;
            enemySpeed += 10f; // Increase enemy speed with each wave
            SpawnEnemyWave(waveCount);
            waveText.text = "Wave: " + waveCount; // Update wave display
        }
        else if (waveCount > 10)
        {
            TriggerWinCondition();
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        ResetPlayerPosition();
    }

    private Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }

    private void ResetPlayerPosition()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void TriggerLossCondition()
    {
        if (!isGameOver)
        {
            lossText.gameObject.SetActive(true);
            isGameOver = true;
            Time.timeScale = 0;
        }
    }

    public void TriggerWinCondition()
    {
        if (!isGameOver)
        {
            winText.gameObject.SetActive(true);
            isGameOver = true;
            Time.timeScale = 0;
        }
    }

    private void RestartGame()
    {
        isGameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncrementWaveOnScore()
    {
        waveCount++;
        enemySpeed += 10f; // Increase enemy speed with the wave
        SpawnEnemyWave(waveCount);
        waveText.text = "Wave: " + waveCount; // Update wave display
    }
}