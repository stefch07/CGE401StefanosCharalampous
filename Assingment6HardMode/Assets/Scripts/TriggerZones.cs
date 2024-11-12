using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZones : MonoBehaviour
{
    bool active = true;

    public AudioClip soulSound;
    private AudioSource zoneAudio;

    private void Start()
    {
        // Set reference variables to components
        zoneAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            // Play collect sound when the player enters the trigger zone
            zoneAudio.PlayOneShot(soulSound, 1.0f);

            // Make the object invisible while sound plays
            active = false;
            this.gameObject.GetComponent<Renderer>().enabled = false; // Makes the object invisible

            // Start a coroutine to delay the destruction after playing the sound
            StartCoroutine(DestroyAfterSound());
        }
    }

    // Coroutine to delay destruction after playing the sound
    IEnumerator DestroyAfterSound()
    {
        // Wait for the duration of the specific audio clip assigned to soulSound
        yield return new WaitForSeconds(soulSound.length);

        // Destroy the GameObject
        Destroy(gameObject);
    }
}