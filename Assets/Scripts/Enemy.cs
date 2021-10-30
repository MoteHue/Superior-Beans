using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount) {
        health = Mathf.Max(health - amount, 0);
        if (health == 0) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
