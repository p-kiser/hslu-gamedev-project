using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = new Vector3(Mathf.Sin(Time.time) + 1, Mathf.Sin(Time.time) + 1, Mathf.Sin(Time.time) + 1);

        transform.localScale = vec;
    }
}
