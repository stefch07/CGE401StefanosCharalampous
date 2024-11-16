/*
 * Stefanos Charalampous
 * PlayerControllerX.cs
 * Assignment 7
 * Handles player movement, turbo boost, and powerup effects.
 */

using System.Collections;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 600f;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    public float normalStrength = 15f; // Strength without powerup
    public float powerupStrength = 30f; // Strength with powerup
    public float turboMultiplier = 1.5f; // Multiplier for turbo boost (adjustable in Inspector)
    public float turboCooldown = 3f;
    public ParticleSystem turboSmoke;

    private bool canUseTurbo = true; // Controls turbo boost cooldown

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && canUseTurbo)
        {
            StartCoroutine(ActivateTurboBoost());
        }

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
    }

    private IEnumerator ActivateTurboBoost()
    {
        canUseTurbo = false;
        turboSmoke.Play();
        playerRb.AddForce(focalPoint.transform.forward * speed * turboMultiplier, ForceMode.Impulse);
        yield return new WaitForSeconds(turboCooldown);
        turboSmoke.Stop();
        canUseTurbo = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    private IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            if (hasPowerup)
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }
        }
    }
}