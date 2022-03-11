using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class PlayerCollisions : MonoBehaviour
{
    public ContactPoint2D[] contacts = new ContactPoint2D[10];
    private Tilemap destroyableMap;
    private bool isAllPuzzleCollected;
    public static Action onPlayerDied;
    public static Action onAllPuzzleCollected;
    public static Action onLevelCompleted;

    private void Awake()
    {
        isAllPuzzleCollected = false;
        destroyableMap = GameObject.FindGameObjectWithTag("Destroyable").GetComponent<Tilemap>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerStats.Lives -= 1;
            if (PlayerStats.Lives <= 0) onPlayerDied?.Invoke();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyable"))
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
            PlayerStats.Score += 1;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("Puzzle"))
        {
            PlayerStats.RemainingPieces -= 1;

            isAllPuzzleCollected = PlayerStats.RemainingPieces == 0;

            Destroy(collision.gameObject);
            if (isAllPuzzleCollected)
            {
                onAllPuzzleCollected?.Invoke();
            }

        }
        else if (collision.gameObject.CompareTag("FinishFlag"))
        {
            if (isAllPuzzleCollected) onLevelCompleted?.Invoke();

        }
    }
}
