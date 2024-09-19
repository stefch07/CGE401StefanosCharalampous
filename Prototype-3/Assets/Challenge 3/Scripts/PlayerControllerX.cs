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
    public float maxY = 15;  // Upper boundary for balloon
    public float minY = 1;   // Lower boundary for balloon
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip groundedSound;

    public Text scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        UpdateScore(); // Initialize score display
    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < maxY)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }

        // If the balloon goes below the ground, bounce it
        if (transform.position.y < minY)
        {
            playerRb.position = new Vector3(playerRb.position.x, minY, playerRb.position.z); // Keep balloon above minY
            playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);  // Apply bounce force
            playerAudio.PlayOneShot(groundedSound, 1.0f);  // Play bounce sound
        }

        // Limit the balloon's y position to prevent it from going above the maxY value
        if (transform.position.y > maxY)
        {
            playerRb.position = new Vector3(playerRb.position.x, maxY, playerRb.position.z); // Clamp position to maxY
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z); // Stop upward velocity
        }

        // Restart the game if 'R' is pressed after game over
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // If player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            scoreText.text = "You lose! Press R to try again!";
            Destroy(other.gameObject);
        }

        // If player collides with money, play fireworks and increase score
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.transform.position = transform.position; // Set fireworks to balloon's position
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

            // Increment score and update UI
            score++;
            UpdateScore();

            // Check win condition
            if (score >= 30)
            {
                gameOver = true;
                scoreText.text = "You win! Press R to try again!";
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}