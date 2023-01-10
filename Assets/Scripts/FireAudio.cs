using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAudio : MonoBehaviour
{
    [Header("Lazer")]
    [SerializeField] AudioClip lazerAudio;
    [SerializeField][Range(0f, 1f)] float lazerVolume = 1f;

    public void PlayLazerAudio()
    {
        AudioSource.PlayClipAtPoint(lazerAudio, Camera.main.transform.position, lazerVolume);
    }


}
