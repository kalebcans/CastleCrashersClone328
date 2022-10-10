using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int maxEnemies;
    public GameObject enemy;
    public float spawnFrequency;

    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnFrequency;
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

        newEnemy.transform.parent = gameObject.transform;
    }
}
