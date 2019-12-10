using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrator : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField]
    float speed = 100;
    [SerializeField]
    float intensity = 1;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float shake = Mathf.Sin(Time.time * speed) * intensity / 100;
        transform.position = startPosition + new Vector3(shake,shake,shake);
    }
}
