using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class PlayerCollisions : MonoBehaviour
{
    public ContactPoint2D[] contacts = new ContactPoint2D[10];
    private Tilemap destroyableMap;
    public static Action onHitEnemy;
    public static Action onCollectPuzzle;
    public static Action onConsumeEdible;
    public static Action onHitFlag;

    private void Awake()
    {
        destroyableMap = GameObject.FindGameObjectWithTag("Destroyable").GetComponent<Tilemap>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            onHitEnemy?.Invoke();
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
            onConsumeEdible?.Invoke();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("Puzzle"))
        {
            onCollectPuzzle?.Invoke();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("FinishFlag"))
        {
            onHitFlag?.Invoke();
        }
    }
}
