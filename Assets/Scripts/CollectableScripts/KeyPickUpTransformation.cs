using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpTransformation : MonoBehaviour
{
    [SerializeField]
    private Transform keyPedestal;

    [SerializeField]
    private Transform returnPosition;

    private void OnTriggerEnter(Collider other)
    { 
        // Teleport the player back to the hub
        if (other.GetComponentInParent<Rigidbody>().tag == "Player" && gameObject.transform.tag != "CollectedKey")
        {
            Transform playerTransform = other.GetComponentInParent<Rigidbody>().transform;
            playerTransform.position = returnPosition.position;
            playerTransform.rotation = returnPosition.rotation;
        }

        // Add the key to the corresponding key pedestal
        gameObject.transform.position = keyPedestal.position + new Vector3(0.0f, 2.0f, 0.0f);
        gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        gameObject.transform.tag = "CollectedKey";

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
