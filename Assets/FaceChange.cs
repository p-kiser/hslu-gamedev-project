using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceChange : MonoBehaviour
{
    [SerializeField]
    Texture[] faces;
    [SerializeField]
    float frequency = 2.0f;

    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        float delay = Random.Range(0.0f, 2.0f);
        InvokeRepeating("changeFace", delay, frequency);
   
    }

    private void changeFace() {
        int rand = Random.Range(0, faces.Length);
        rend.material.mainTexture = faces[rand];

    }
}
