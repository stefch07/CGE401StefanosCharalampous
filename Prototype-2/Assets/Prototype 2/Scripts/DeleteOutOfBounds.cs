/*
* Stefanos Charalampous
* Assignment 3
* Deletes out of bounds projectiles and animals
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;
    // Update is called once per frame
    void Update()
    {
        if (transform. position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < bottomBound)
        {
            Debug. Log("Game Over!");
            Destroy (gameObject);
        }
    }
}
