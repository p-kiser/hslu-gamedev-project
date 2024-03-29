﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
    }
}
