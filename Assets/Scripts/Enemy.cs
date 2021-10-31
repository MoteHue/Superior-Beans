using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public Rigidbody rb;
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
        //Physics.gravity *= 2f;
        //remainingJumps = maxJumps;
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
        DoBehaviour();
    }

    virtual public void DoBehaviour() {
        // override this function
    }

    private void OnCollisionStay(Collision collision){
        if (collision.gameObject.layer == 6) AttackPlayer(10);
    }

    public void AttackPlayer(int damage){
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
