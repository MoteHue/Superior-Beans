using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    Rigidbody rb;
    bool canAttack = true;
    public int attackDamage = 10;

    public Transform player;
    public PlayerController playerController;

    EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        player = playerController.gameObject.transform;
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
    }

    public void Setup(EnemySpawner spawner) {
        enemySpawner = spawner;
    }

    public void TakeDamage(int amount) {
        health = Mathf.Max(health - amount, 0);
        if (health == 0) {
            Die();
        }
    }

    void Update(){
        GoToPlayer(0.1f);
        if (Vector3.Distance(player.position, transform.position) < .5f) AttackPlayer(attackDamage);
        transform.LookAt(player);
    }

    void GoToPlayer(float s){
        Vector3 direction = new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z).normalized;
        if ((new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z).magnitude > 1f)) {
            rb.MovePosition(transform.position - s * direction);
        }
        //if ((xyDistance < 1f) && (player.position.y > transform.position.y)) Jump();
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
        if (enemySpawner != null) enemySpawner.AlertEnemyDied();
        Destroy(gameObject);
    }
}
