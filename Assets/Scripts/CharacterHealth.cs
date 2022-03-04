using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth
{
    private int _health;
    private int _maxHealth;
    public int MaxHealth
    {
        set
        {
            _maxHealth = value;
        }
        get
        {
            return _maxHealth;
        }
    }
    public int Health
    {
        set
        {
            _health = value;
        }

        get
        {
            return _health;
        }
    }

    public CharacterHealth(int maxHealth)
    {
        MaxHealth = maxHealth;
        Health = maxHealth;
    }
    private void CheckHealth()
    {
        if (Health <= 0)
        {
            Health = 0;
        }

        else if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        CheckHealth();
    }

    public void Heal(int heal)
    {
        Health += heal;
        CheckHealth();
    }
}
