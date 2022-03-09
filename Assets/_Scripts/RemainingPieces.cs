using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingPieces : MonoBehaviour
{
    [SerializeField] Text remainingPuzzleText;

    void Update()
    {
        remainingPuzzleText.text = "Remaining Pieces: " + PlayerStats.RemainingPieces.ToString();
    }
}
