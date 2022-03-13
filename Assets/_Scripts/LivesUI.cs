using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [SerializeField] Text livesText;

    private void Awake()
    {
        UpdateText();
    }
    private void OnEnable()
    {
        PlayerCollisions.onHitEnemy += UpdateText;
    }

    private void OnDisable()
    {
        PlayerCollisions.onHitEnemy -= UpdateText;
    }

    // Update is called once per frame
    void UpdateText()
    {
        livesText.text = "Lives: " + GameStats.instance.Lives.ToString();
    }
}
