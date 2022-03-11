using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int curLevel;

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
        PlayerCollisions.onPlayerDied += GameOver;
        PlayerCollisions.onLevelCompleted += LoadNextLevel;
        
    }

    private void OnDisable()
    {
        PlayerCollisions.onPlayerDied -= GameOver;
        PlayerCollisions.onLevelCompleted -= LoadNextLevel;
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");
    }

    private void LoadNextLevel()
    {
        curLevel += 1;
        Debug.Log("Load Level" + curLevel);
    }


}
