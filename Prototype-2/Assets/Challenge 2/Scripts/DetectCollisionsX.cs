/*
* Stefanos Charalampous
* Assignment 3
* Detects collisions with dogs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog"))
        {
            Destroy(gameObject);
            gameManager.IncrementScore();
        }
    }
}