using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{

    public static UiController instance;

    [SerializeField]
    PlayerStatus player;

    [SerializeField]
    Slider healthBar;

    [SerializeField]
    TextMeshProUGUI score;

    [SerializeField]
    GameObject key1;
    [SerializeField]
    GameObject key2;
    [SerializeField]
    GameObject key3;
    int prevCollectedKeys;
    int collectedKeys;

    int testCounter;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        prevCollectedKeys = player.GetKeysCollected();
        key1.SetActive(false);
        key2.SetActive(false);
        key3.SetActive(false);
    }

    public void UpdateUI()
    {
        healthBar.value = player.GetHealth();
        score.text = "" + player.GetPoints();
        collectedKeys = player.GetKeysCollected();

        if (collectedKeys > prevCollectedKeys)
        {
            DisplayKeys(collectedKeys);
            prevCollectedKeys = collectedKeys;
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
