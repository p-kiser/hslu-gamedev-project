using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [SerializeField]
    public Transform Destination;
    [SerializeField]
    private AudioClip sound;

    PlayerStatus playerStatus;

    private void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
    }

    public void OnTriggerEnter(Collider other)
    {   
        Rigidbody rb = other.GetComponentInParent<Rigidbody>();
        if (rb != null)
        {
            // Teleport the player
            rb.transform.position = Destination.transform.position;
            rb.transform.rotation = Destination.transform.rotation;

            AudioSource.PlayClipAtPoint(sound, rb.transform.position, 1);

            // Set a new respawn position of the Player when he dies
            if (other.gameObject.tag == "Player")
            {
                playerStatus.RespawnPosition = Destination.transform;
            }
        }
    }
}
