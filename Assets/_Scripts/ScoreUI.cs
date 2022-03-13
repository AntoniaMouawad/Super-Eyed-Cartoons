using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;

    private void Awake()
    {
        UpdateText();
    }
    private void OnEnable()
    {
        PlayerCollisions.onConsumeEdible += UpdateText;
    }

    private void OnDisable()
    {
        PlayerCollisions.onConsumeEdible -= UpdateText;
    }

    // Update is called once per frame
    void UpdateText()
    {
        scoreText.text = "Score: " + GameStats.instance.Score.ToString();
    }
}

