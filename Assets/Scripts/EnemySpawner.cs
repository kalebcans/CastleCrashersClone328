using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int maxEnemies;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkEnemyCount() < maxEnemies)
        {
            spawnEnemy();
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
