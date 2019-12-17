using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    void Awake()
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

    public void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R)) { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
