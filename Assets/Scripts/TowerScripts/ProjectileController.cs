using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    GameObject gob;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Deactivate", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Deactivate() {
        gameObject.SetActive(false);
        Debug.Log("Did a deactivate");

    }
}
