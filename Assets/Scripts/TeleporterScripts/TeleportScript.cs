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
        Rigidbody playerRb = other.GetComponentInParent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.transform.position = Destination.transform.position;
            playerRb.transform.rotation = Destination.transform.rotation;
        }
    }
}
