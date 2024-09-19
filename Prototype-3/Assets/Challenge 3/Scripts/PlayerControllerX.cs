/*
 * Stefanos Charalampous
 * PlayerControllerX.cs
 * Assignment 4
 * This script controls the players movement and other functions in the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    public float bounceForce;
    private float gravityModifier = 1.5f;
    public float maxY = 15;  
    public float minY = 1; 
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip groundedSound;

    public Text scoreText;
    private int score = 0;

    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        UpdateScore(); 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < maxY)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        if (transform.position.y < minY)
        {
            playerRb.position = new Vector3(playerRb.position.x, minY, playerRb.position.z);
            playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);  
            playerAudio.PlayOneShot(groundedSound, 1.0f);  
        }

        if (transform.position.y > maxY)
        {
            playerRb.position = new Vector3(playerRb.position.x, maxY, playerRb.position.z);
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z); 
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            scoreText.text = "You lose!\nPress R to try again!";
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.transform.position = transform.position; 
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

            score++;
            UpdateScore();

            if (score >= 30)
            {
                gameOver = true;
                scoreText.text = "You win!\nPress R to try again!";
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}