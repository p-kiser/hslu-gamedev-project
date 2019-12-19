using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip damageSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") ||
            other.gameObject.CompareTag("EnemyBig"))
        {
            AudioSource.PlayClipAtPoint(damageSound, gameObject.transform.position);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            AudioSource.PlayClipAtPoint(damageSound, gameObject.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || 
            collision.gameObject.CompareTag("EnemyBig"))
        {
            AudioSource.PlayClipAtPoint(damageSound, gameObject.transform.position);
        }
    }
}
