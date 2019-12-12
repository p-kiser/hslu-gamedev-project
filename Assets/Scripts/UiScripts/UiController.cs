using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    PlayerStatus player;
    [SerializeField]
    Text scoreText;
    string s = "Score: ";

    // stuff to display
    int points;
    int health;
    bool onSpeed;
    bool invincible;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        points = player.GetPoints();
        health = player.GetHealth();
        onSpeed = player.IsOnSpeed();
        invincible = player.IsInvincible();

        // display 
        scoreText.text = "score: " + points + " | health: " + health + " | speedUgrade: " + onSpeed + " | invincible: " + invincible;
    }
}
