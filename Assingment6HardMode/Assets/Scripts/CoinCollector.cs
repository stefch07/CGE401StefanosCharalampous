using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour

{
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter(Collider collision)
    {
        if (collectionSoundEffect != null && collectionSoundEffect.enabled)
                {
                    collectionSoundEffect.Play();
                }
    }
}
