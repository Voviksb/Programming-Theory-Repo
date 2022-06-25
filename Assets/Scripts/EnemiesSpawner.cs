using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EnemiesSpawner : MonoBehaviour
{
    public static EnemiesSpawner Instance { get; private set; }

    [SerializeField] Vector3[] spawnPositions = new Vector3[5];
    [SerializeField] private int _enemiesAlive;


    [SerializeField] private EnemyBehavior _enemyPrefab;
    private PoolMono<EnemyBehavior> _enemiesPool;

    public delegate void LevelSpawnerHandler(int value);
    public event LevelSpawnerHandler OnEnemiesCountChangeEvent;

    public event Action OnAllEnemiesDeadEvent;

    public List<GameObject> enemies;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        _enemiesPool = new PoolMono<EnemyBehavior>(_enemyPrefab, 8, this.transform, true);
    }

    public void SpawnEnemies(int _enemiesToSpawn)
    {
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            var enemyCreated = _enemiesPool.GetFreeElement();
            enemyCreated.transform.position = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)];
            enemies.Add(enemyCreated.gameObject);
        }
        this.OnEnemiesCountChangeEvent?.Invoke(enemies.Count);
    }

    public void OnEnemyDeath(GameObject enemy)
    {
        enemies.Remove(enemy);
        this.OnEnemiesCountChangeEvent?.Invoke(enemies.Count);
        if (enemies.Count == 0)
        {
            this.OnAllEnemiesDeadEvent?.Invoke();
        }
    }
}
