using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Tooltip("Rotation around the x-axis in degreés per seconds")]
    [SerializeField]
    private float x = 0;
    [SerializeField]
    private float y = 0;
    [SerializeField]
    private float z = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }
}