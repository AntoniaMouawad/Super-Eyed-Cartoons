using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStats : MonoBehaviour
{
    public int Score{ get; set; }
    public int Lives { get; set; }
    public int RemainingPieces { get; set; }
    public static GameStats instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

        Score = 0;
        Lives = 3;
        RemainingPieces = 4;
    }

    private void OnEnable()
    {
        PlayerCollisions.onHitKiller += LoseLife;
        PlayerCollisions.onConsumeEdible += IncreaseScore;
        PlayerCollisions.onPuzzleConsumed += ConsumePuzzle;
    }

    private void OnDisable()
    {
        PlayerCollisions.onHitKiller -= LoseLife;
        PlayerCollisions.onConsumeEdible -= IncreaseScore;
        PlayerCollisions.onPuzzleConsumed -= ConsumePuzzle;
    }

    public void LoseLife()
    {
        Lives -= 1;
    }

    public void IncreaseScore()
    {
        Score += 1;
    }

    public void ConsumePuzzle()
    {
        RemainingPieces -= 1;
    }

}
