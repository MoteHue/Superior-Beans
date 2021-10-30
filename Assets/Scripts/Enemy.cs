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
    bool canAttack = true;
    public int attackDamage = 10;

    public Transform player;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        player = playerController.gameObject.transform;
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
        if (Vector3.Distance(player.position, transform.position) < .5f) AttackPlayer(attackDamage);
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

    private void OnCollisionStay(Collision collision){
        if (collision.gameObject.layer == 6) AttackPlayer(10);
    }

    void AttackPlayer(int damage){
        if (canAttack){
            canAttack = false;
            //player.PlayerController.TakeDamage(damage);
            playerController.TakeDamage(damage);
            StartCoroutine(DeactivateAfterTime(1f));
        }
    }

    IEnumerator DeactivateAfterTime(float time) {
        yield return new WaitForSecondsRealtime(time);
        canAttack = true;
    }

    void Die() {
        Destroy(gameObject);
    }
}
