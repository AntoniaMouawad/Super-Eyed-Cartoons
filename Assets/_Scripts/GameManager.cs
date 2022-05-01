using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int curLevel;
    public static Action onPuzzleReset;
    // losing life -> keep score, keep life, reset puzzle

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        curLevel = 1;
    }

    private void OnEnable()
    {
        PlayerCollisions.onGameOver += GameOver;
        PlayerCollisions.onHitKiller += RestartLevel;
        PlayerCollisions.onHitFlag += LoadNextLevel;
        
    }

    private void OnDisable()
    {
        PlayerCollisions.onGameOver -= GameOver;
        PlayerCollisions.onHitKiller -= RestartLevel;
        PlayerCollisions.onHitFlag -= LoadNextLevel;
    }


    void LoadNextLevel()
    {
        ResetPuzzle();
        curLevel += 1;
        SceneManager.LoadScene("Level_" + curLevel);


    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");
    }

    private void ResetPuzzle()
    {
        GameStats.instance.RemainingPieces = 4; // Todo: sooo ugly, needs to be fixed
        onPuzzleReset?.Invoke();


    }

    private void RestartLevel()
    {
        ResetPuzzle();
        SceneManager.LoadScene("Level_" + curLevel);
    }
}
