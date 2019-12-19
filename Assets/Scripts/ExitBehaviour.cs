using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (PlayerStatus.instance.GetKeysCollected() == 3)
        {
            Invoke("RestartGame", 2.0f);
        }
    }
    private void RestartGame() { GameController.instance.RestartGame(); }
}
