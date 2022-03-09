using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Score;
    [SerializeField] private int startScore = 0;

    public static int Lives;
    [SerializeField] private int startLives = 3;

    private void Start()
    {
        Lives = startLives;
        Score = startScore;
    }

}
