using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    Text scoreText;
    string s = "Score: ";


    int points;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        points = player.GetPoints();
        scoreText.text = s + points.ToString();
        Debug.Log(points);
    }
}
