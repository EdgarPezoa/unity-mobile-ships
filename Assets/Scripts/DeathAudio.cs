using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAudio : MonoBehaviour
{
    [Header("Death")]
    [SerializeField] AudioClip deathAudio;
    [SerializeField][Range(0f, 1f)] float deathVolume = 1f;

    public void PlayDeathAudio()
    {
        AudioSource.PlayClipAtPoint(deathAudio, Camera.main.transform.position, deathVolume);
    }
}
