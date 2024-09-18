/*
* Stefanos Charalampous
* Assignment 3
* Controls dog spawning
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canSpawn = true;
    private float spawnCooldown = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            StartCoroutine(SpawnCooldown());
        }
    }

    IEnumerator SpawnCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnCooldown);  
        canSpawn = true;
    }
}