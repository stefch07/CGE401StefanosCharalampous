using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5f;
    private float forwardInput;
    private GameObject focalPoint;
    public bool hasPowerup;
    private float powerupStrength = 15.0f; // Strength of the power-up effect
    public GameObject powerupIndicator; // Indicator for the power-up

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
        powerupIndicator.SetActive(false); // Ensure the indicator is inactive at the start
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        // Position the power-up indicator below the player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true); // Activate the power-up indicator
            StartCoroutine(PowerupCountdownRoutine()); // Start coroutine to end power-up after a duration
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); // Power-up lasts for 7 seconds
        hasPowerup = false;
        powerupIndicator.SetActive(false); // Deactivate the power-up indicator
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Player collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);

            // Get the enemy's Rigidbody
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // Calculate direction away from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            // Apply an impulse force to the enemy away from the player
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}