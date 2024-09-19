/*
 * Stefanos Charalampous
 * MoveLeft.cs
 * Assignment 4
 * This script moves objects to the left and destroys them when they go off-screen
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
	private float speed = 20;
	private PlayerController playerControllerScript;
	private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
		if (playerControllerScript.gameOver == false)
		{
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}

		if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
		{
			Destroy(gameObject);
		}
    }
}