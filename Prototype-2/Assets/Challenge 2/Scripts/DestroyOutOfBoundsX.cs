/*
* Stefanos Charalampous
* Assignment 3
* Deletes out of bounds projectiles and animals
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float bottomLimit = -5;
    private HealthSystem healthSystem;

    void Start()
    {
        healthSystem = GameObject.Find("HealthSystem").GetComponent<HealthSystem>();  // Assuming your HealthSystem is tagged or named
    }

    void Update()
    {
        if (transform.position.y < bottomLimit)
        {
            healthSystem.TakeDamage(); // Call to take damage
            Destroy(gameObject);
        }
    }
}