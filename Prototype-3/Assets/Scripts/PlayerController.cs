using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Rigidbody
        rb = GetComponent<Rigidbody>();
        
        // Initialize the Animator
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Speed_f", 1.0f);

        // Initialize the AudioSource
        playerAudio = GetComponent<AudioSource>();

        // Set the gravity and jump force mode
        jumpForceMode = ForceMode.Impulse;

        // Apply the gravity modifier if necessary
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            // Trigger jump animation and stop dirt particles
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();

            // Play jump and crash sounds
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over!");
            gameOver = true;

            // Trigger death animation and play explosion particle
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();

            // Play crash sound
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}