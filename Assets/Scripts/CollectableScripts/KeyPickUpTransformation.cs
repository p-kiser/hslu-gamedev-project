using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpTransformation : MonoBehaviour
{
    [SerializeField]
    private Transform keyPedestal;

    private void OnTriggerEnter(Collider other)
    {
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
