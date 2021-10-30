using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFGProjectile : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public int damageAmount = 10;
    Rigidbody rb;
    public GameObject deathEffect;

    private void Start() {
        rb = FindObjectOfType<Rigidbody>();
        //rb.AddForce(transform.forward * moveSpeed);
        Invoke(nameof(Die), 3f);
    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.TryGetComponent(out Enemy enemy)) { 
            enemy.TakeDamage(damageAmount);
        }
        Die();
    }

    void Die() {
        if (deathEffect != null) Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
