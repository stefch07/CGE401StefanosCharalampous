using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody enemyRb; 
    public GameObject player;
    public float speed = 3.0f;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        // Destroy the enemy if it falls below a certain height
        if (transform.position.y < -10) 
        {
            Destroy(gameObject);
        }
    }
}