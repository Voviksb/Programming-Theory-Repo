using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSpawner : MonoBehaviour
{
    public static LevelSpawner Instance { get; private set; }

    
    [SerializeField] Vector3[] spawnPositions = new Vector3[5];
    [SerializeField] private int _wavesLeft;
    [SerializeField] private int _enemiesToSpawn;
    [SerializeField] private int _enemiesAlive;
    [SerializeField] private int _currentWave = 0;

    [SerializeField] private EnemyBehavior _enemyPrefab;
    private PoolMono<EnemyBehavior> _enemiesPool;

    public delegate void GameManagerHandler(int value);
    public event GameManagerHandler OnWavesChangedEvent;
    public event GameManagerHandler OnEnemiesCountChangeEvent;

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
    }

    private void Start()
    {
        _enemiesPool = new PoolMono<EnemyBehavior>(_enemyPrefab, 8, this.transform, true);
        SpawnEnemies(_enemiesToSpawn);
    }

    public void OnEnemyDeath(GameObject enemy)
    {
        enemies.Remove(enemy);
        this.OnEnemiesCountChangeEvent?.Invoke(enemies.Count);
        if (enemies.Count == 0 && _wavesLeft > 0)
        {
            _enemiesToSpawn++;
            SpawnEnemies(_enemiesToSpawn);
        }
    }

    private void SpawnEnemies(int _enemiesToSpawn)
    {
        _wavesLeft--;
        _currentWave++;
        this.OnWavesChangedEvent?.Invoke(_currentWave);
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            var enemyCreated = _enemiesPool.GetFreeElement();
            enemyCreated.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)];
            enemies.Add(enemyCreated.gameObject);
        }
        this.OnEnemiesCountChangeEvent?.Invoke(enemies.Count);
    }
}
