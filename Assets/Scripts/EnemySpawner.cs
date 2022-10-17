using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int maxEnemies;
    public int minSpawnDistance;
    public int maxSpawnDistance;
    public GameObject enemy;
    public float spawnFrequency;

    private float spawnTimer;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnFrequency;
        player = GameObject.FindGameObjectWithTag("Player");
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
    }

    int checkEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void spawnEnemy ()
    {
        GameObject newEnemy = Instantiate(enemy);

        newEnemy.transform.position = player.transform.position;

        // spawn enemy closer to player
        int distance = Random.Range(-maxSpawnDistance, maxSpawnDistance);
        // dont let enemy spawn too close
        while (Mathf.Abs (distance) < minSpawnDistance)
        {
            distance = Random.Range(-maxSpawnDistance, maxSpawnDistance);
        }
        newEnemy.transform.position += new Vector3 (distance, 0, 0);
    }
}
