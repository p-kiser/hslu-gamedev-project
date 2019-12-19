using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject specialCoin;


    private void OnCollisionEnter(Collision collision)
    {
        if (PlayerStatus.instance.GetKeysCollected() == 3)
        {
            GibSpecialCoin();
            Invoke("RestartGame", 2.0f);
        }
    }

    public void GibSpecialCoin() { specialCoin.SetActive(true); }

    private void RestartGame() { GameController.instance.RestartGame(); }
}
