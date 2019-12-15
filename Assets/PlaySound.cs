using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]
    AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if (!sound.isPlaying) { sound.Play(); }
    }
}
