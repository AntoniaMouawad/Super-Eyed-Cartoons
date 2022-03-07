using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerColliding : MonoBehaviour
{
    private CharacterHealth healthSystem;
    public ContactPoint2D[] contacts = new ContactPoint2D[10];
    private Tilemap destroyableMap;
    private int totalCollected, nPiecesLeft;
    [SerializeField] private Text scoreText; //Todo: Take this out of the current class somehow

    private void Awake()
    {
        healthSystem = new CharacterHealth(100);
        destroyableMap = GameObject.FindGameObjectWithTag("Destroyable").GetComponent<Tilemap>();
        totalCollected = 0;
        nPiecesLeft = 4;
        scoreText.text = "Score: 0";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthSystem.TakeDamage(20);
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyable") )
         { 
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                destroyableMap.SetTile(destroyableMap.WorldToCell(hitPosition), null);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edible"))
        {
            Destroy(collision.gameObject);
            totalCollected += 1;
            scoreText.text = "Score: " + totalCollected;
        }
        else if (collision.gameObject.CompareTag("Puzzle"))
        {
            Destroy(collision.gameObject);
            nPiecesLeft -= 1;
            Debug.Log(nPiecesLeft);
        }
    }
}
