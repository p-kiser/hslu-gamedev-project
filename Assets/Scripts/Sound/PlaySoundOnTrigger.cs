using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
    }

}
