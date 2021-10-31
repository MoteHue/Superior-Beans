using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> possibleEnemies;
    public GameObject EnemyPrefab;
    public int maxEnemiesAtOnce = 3;
    public int maxTotalEnemiesAllowed = 5;
    int enemiesSpawned;
    int enemiesAlive;
    public float timeBetweenSpawns = 3f;
    float timePassed;
    public bool canSpawn = true;

    void SpawnEnemy() {
        if (canSpawn && enemiesSpawned < maxTotalEnemiesAllowed) {
            enemiesAlive++;
            enemiesSpawned++;
        }
        GameObject enemy = Instantiate(EnemyPrefab, transform.position, transform.rotation);
        enemy.GetComponent<Enemy>().Setup(this);
    }

    // Update is called once per frame
    void Update() {
        timePassed += Time.deltaTime;
        if (timePassed > timeBetweenSpawns && enemiesAlive < maxEnemiesAtOnce && canSpawn && enemiesSpawned < maxTotalEnemiesAllowed) {
            timePassed = 0f;
            SpawnEnemy();
        }
    }

    public void AlertEnemyDied() {
        enemiesAlive--;
    }

    public void Configue(int y, int maxY) {
        int i = Random.Range(0, possibleEnemies.Count);
        EnemyPrefab = possibleEnemies[i];
    }
}
