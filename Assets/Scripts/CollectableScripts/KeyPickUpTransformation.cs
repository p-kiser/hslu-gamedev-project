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
        if (other.CompareTag("Player") && gameObject.CompareTag("Key"))
        {
            PlayerStatus.instance.CollectKey();

            // Teleport player back to the hub
            Transform playerTransform = other.attachedRigidbody.transform;
            playerTransform.position = returnPosition.position;
            playerTransform.rotation = returnPosition.rotation;

            // Add the key to the corresponding key pedestal
            gameObject.transform.position = keyPedestal.position + new Vector3(0.0f, 2.0f, 0.0f);
            gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            gameObject.transform.tag = "CollectedKey";

        }
    }
}
