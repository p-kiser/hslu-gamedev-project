using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    GameObject obj;

    private void Start()
    {
        obj = GetComponent<GameObject>();
        Invoke("Deactivate", 2.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void Deactivate() {
        obj.SetActive(false);
    }
}
