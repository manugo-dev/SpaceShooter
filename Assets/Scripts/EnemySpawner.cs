using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool<Enemy> enemyPool;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private Vector2 spawnAreaMin;
    [SerializeField] private Vector2 spawnAreaMax;

    private float spawnTimer; 

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void FixedUpdate()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        Enemy enemy = enemyPool.GetObject();

        float spawnX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float spawnY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        enemy.transform.position = new Vector2(spawnX, spawnY);
    }
}