using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int totalEnemies = 10;
    public int maxEnemies = 3;
    public int minSpawnDistance = 5;
    public int maxSpawnDistance = 7;
    public GameObject enemy;
    public float spawnFrequency;

    private int enemiesSpawned;
    private float spawnTimer;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnFrequency;
        player = GameObject.FindGameObjectWithTag("Player");
        enemiesSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (checkEnemyCount() < maxEnemies && spawnTimer <= 0)
        {
            spawnEnemy();
            spawnTimer = spawnFrequency;
        }

        if (enemiesSpawned == totalEnemies)
        {
            Destroy(this.gameObject);
        }
    }

    int checkEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void spawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemy);

        newEnemy.transform.position = player.transform.position;

        // spawn enemy closer to player
        int distance = Random.Range(-maxSpawnDistance, maxSpawnDistance);
        // dont let enemy spawn too close
        while (Mathf.Abs(distance) < minSpawnDistance)
        {
            distance = Random.Range(-maxSpawnDistance, maxSpawnDistance);
        }

        newEnemy.transform.position += new Vector3(distance, -player.transform.position.y, 0);

        enemiesSpawned += 1;
    }
}