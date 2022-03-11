using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineUI : MonoBehaviour
{

    private GameObject FinishLineOn;
    private void Awake()
    {
        FinishLineOn = GameObject.FindGameObjectWithTag("FinishFlag");
        FinishLineOn.SetActive(false);
    }
    private void OnEnable()
    {
        PlayerCollisions.onAllPuzzleCollected += TurnOnFinishLine;
    }

    private void TurnOnFinishLine()
    {
        FinishLineOn.SetActive(true);
    }
}
