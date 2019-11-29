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

    // stuff to display
    int points;
    int health;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        points = player.GetPoints();
        health = player.GetHealth();
        // display 
        scoreText.text = "Score: " + points + ", health: " + health;
        Debug.Log(points);
    }
}
