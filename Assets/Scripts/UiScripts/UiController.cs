using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    PlayerStatus player;

    [SerializeField]
    Slider healthBar;

    [SerializeField]
    Text score;

    [SerializeField]
    GameObject key1;
    [SerializeField]
    GameObject key2;
    [SerializeField]
    GameObject key3;
    int prevCollectedKeys;
    int collectedKeys;

    int testCounter;


    // Start is called before the first frame update
    void Start()
    {
        prevCollectedKeys = player.GetKeysCollected();
        key1.SetActive(false);
        key2.SetActive(false);
        key3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = player.GetHealth();
        score.text = "Score: " + player.GetPoints();
        collectedKeys = player.GetKeysCollected();

        // TODO Remove when player.GetKeysCollected() works again
        testCounter++;
        if (testCounter > 300)
        {
            if (testCounter > 600)
            {
                if (testCounter > 900)
                {
                    DisplayKeys(3);
                    return;
                }
                DisplayKeys(2);
                return;
            }
            DisplayKeys(1);
            return;

        }

        if (collectedKeys > prevCollectedKeys)
        {
            DisplayKeys(collectedKeys);
        }
    }

    private void DisplayKeys(int collectedKeys)
    {
        switch (collectedKeys)
        {
            case 1:
                key1.SetActive(true);
                break;
            case 2:
                key2.SetActive(true);
                break;
            case 3:
                key3.SetActive(true);
                break;
        }
    }
}
