using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int maxEnemies = 3;
    int enemiesAlive;
    public float timeBetweenSpawns = 3f;
    float timePassed;
    public bool canSpawn = true;

    void SpawnEnemy() {
        enemiesAlive++;
        GameObject enemy = Instantiate(EnemyPrefab, transform.position, transform.rotation);
        enemy.GetComponent<Enemy>().Setup(this);
    }

    // Update is called once per frame
    void Update() {
        timePassed += Time.deltaTime;
        if (timePassed > timeBetweenSpawns && enemiesAlive < maxEnemies && canSpawn) {
            timePassed = 0f;
            SpawnEnemy();
        }
    }

    public void AlertEnemyDied() {
        enemiesAlive--;
    }
}
