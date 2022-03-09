using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;

    private void Update()
    {
        scoreText.text = "Score: " + PlayerStats.Score.ToString();
    }
}

