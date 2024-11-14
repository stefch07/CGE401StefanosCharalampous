using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public GameObject powerupPrefab; // Power-up prefab to spawn
    private float spawnRange = 9f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the initial wave of enemies and a power-up
        SpawnEnemyWave(waveNumber);
        SpawnPowerup(1);
    }

    // Method to spawn a wave of enemies
    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Method to spawn power-ups
    private void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    // Method to generate a random position on the platform
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Count the number of enemies currently in the scene
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // If no enemies are left, spawn a new wave and a power-up
        if (enemyCount == 0)
        {
            waveNumber++; // Increment the wave number
            SpawnEnemyWave(waveNumber); // Spawn a new wave with enemies equal to the wave number
            SpawnPowerup(1); // Spawn one power-up
        }
    }
}