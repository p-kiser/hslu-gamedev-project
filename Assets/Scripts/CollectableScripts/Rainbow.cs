using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    [SerializeField]
    private float frequency = 0.1337f;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        ChangeColor();
    }

    private void ChangeColor()
    {
        rend.material.SetColor("_EmissionColor", UnityEngine.Random.ColorHSV());
        Invoke("ChangeColor", frequency);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
