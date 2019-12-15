using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBox : MonoBehaviour
{
    private Vector3 respawnPosition;
    private Quaternion respawnRotation;

    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Deathzone"))
        {
            Debug.Log("MoveableBox respawned");
            Respawn();
        }
    }

    private void Respawn()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = respawnPosition;
        transform.rotation = respawnRotation;
    }
}
