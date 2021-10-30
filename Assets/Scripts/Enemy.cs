using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    Rigidbody rb;
    public int maxJumps = 2;
    int remainingJumps;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
        Physics.gravity *= 2f;
        remainingJumps = maxJumps;
    }

    public void TakeDamage(int amount) {
        health = Mathf.Max(health - amount, 0);
        if (health == 0) {
            Die();
        }
    }

    void Update(){
        GoToPlayer(0.1f);
        if (rb.velocity.y < -0.5f) Jump();
    }

    void GoToPlayer(float s){
        Vector3 direction = new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z).normalized;
        rb.MovePosition(transform.position - s*direction);
    }

    void Jump(){
        if (remainingJumps > 0){
            Vector3 vel = rb.velocity;
            vel.y = 0f;
            rb.velocity = vel;
            rb.AddForce(Vector3.up * 60000f);
            remainingJumps--;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        remainingJumps = maxJumps;
    }

    void Die() {
        Destroy(gameObject);
    }
}
