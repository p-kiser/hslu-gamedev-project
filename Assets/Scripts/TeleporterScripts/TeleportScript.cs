using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [SerializeField]
    public Transform Destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {   
        Rigidbody rb = other.GetComponentInParent<Rigidbody>();
        if (rb != null)
        {
            // Teleport the player
            rb.transform.position = Destination.transform.position;
            rb.transform.rotation = Destination.transform.rotation;

            // Set a new respawn position of the Player when he dies
            PlayerStatus playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();

            if (other.gameObject.tag == "Player") // Make sure only the player can change the respawn position
            {
                playerStatus.RespawnPosition = Destination.transform;
            }
        }
    }
}
