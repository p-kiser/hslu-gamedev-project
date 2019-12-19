using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsator : MonoBehaviour
{
    [Tooltip("How fast the object pulsates")]
    [SerializeField]
    private float frequency = 2;

    [SerializeField]
    private float intensity = 1;

    private Vector3 origSize;

    // Start is called before the first frame update
    void Start()
    {
        origSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float v = Mathf.Sin(Time.time * frequency);
        Vector3 vec = new Vector3(v,v,v);

        transform.localScale = origSize + vec * intensity/10;
    }
}
