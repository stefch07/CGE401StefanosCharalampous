/*
* Stefanos Charalampous
* Assignment 3
* Spawns random balls
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;
    private float startDelay = 1.0f;

    void Start()
    {
        StartCoroutine(SpawnRandomBallWithInterval());
    }

    IEnumerator SpawnRandomBallWithInterval()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            SpawnRandomBall();
            float randomInterval = Random.Range(3f, 5f);
            yield return new WaitForSeconds(randomInterval);
        }
    }

    void SpawnRandomBall()
    {
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }
}