using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliding : MonoBehaviour
{
    private CharacterHealth healthSystem;

    private void Awake()
    {
        healthSystem = new CharacterHealth(100);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthSystem.TakeDamage(10);
            Destroy(collision.gameObject);
        }
    }
}
