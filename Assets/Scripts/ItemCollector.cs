using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int totalCollected;
    [SerializeField] private Text scoreText; //Todo: Take this out of the current class somehow

    private void Awake()
    {
        totalCollected = 0;
        scoreText.text = "Score: 0";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edible"))
        {
            Destroy(collision.gameObject);
            totalCollected += 1;
            scoreText.text = "Score: " + totalCollected;
        }
    }
}
