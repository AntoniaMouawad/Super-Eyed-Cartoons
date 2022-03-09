using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    public ContactPoint2D[] contacts = new ContactPoint2D[10];
    private Tilemap destroyableMap;

    private void Awake()
    {
        destroyableMap = GameObject.FindGameObjectWithTag("Destroyable").GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerStats.Lives -= 1;
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
            PlayerStats.Score += 1;
            Destroy(collision.gameObject);
            
        }
        else if (collision.gameObject.CompareTag("Puzzle"))
        {
            Destroy(collision.gameObject);
            //todo: handle this
            
        }
    }
}
