using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    private bool isBouncing = false;
    [SerializeField]
    public float bounceForce = 10f;
    private GameObject player;
    private Rigidbody playerRb;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            isBouncing = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBouncing)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.y, 0, playerRb.velocity.z);
            playerRb.AddForce(Vector3.up * bounceForce, ForceMode.VelocityChange);
            isBouncing = false;
        }
    }
}
