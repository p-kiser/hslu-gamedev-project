﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{

    [SerializeField]
    private float bounceUpForce;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("DAMN you killed that tower hard!");
            GameObject.Destroy(gameObject);
            other.attachedRigidbody.AddForce(Vector3.up * bounceUpForce, ForceMode.Impulse);
        }
    }
}
