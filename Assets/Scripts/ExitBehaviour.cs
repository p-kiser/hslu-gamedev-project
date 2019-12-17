using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehaviour : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (PlayerStatus.instance.GetKeysCollected() == 3) { GameController.instance.RestartGame(); }
    }
}
