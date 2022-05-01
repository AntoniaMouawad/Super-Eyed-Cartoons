using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingPieces : MonoBehaviour
{
    [SerializeField] Text remainingPuzzleText;

    private void Awake()
    {
        UpdateText();
    }
    private void OnEnable()
    {
        PlayerCollisions.onPuzzleConsumed += UpdateText;
        GameManager.onPuzzleReset += UpdateText;
    }

    private void OnDisable()
    {
        PlayerCollisions.onPuzzleConsumed -= UpdateText;
        GameManager.onPuzzleReset -= UpdateText;
    }

    // Update is called once per frame
    void UpdateText()
    {
        remainingPuzzleText.text = "Remaining Puzzle: " + GameStats.instance.RemainingPieces.ToString();
    }
}
