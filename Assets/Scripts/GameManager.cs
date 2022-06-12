using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    
    [SerializeField] Vector3[] spawnPositions = new Vector3[5];
    [SerializeField] private int _wavesNumber;
    [SerializeField] private int _enemiesNumber;
    [SerializeField] private int _currentWave = 0;

    [SerializeField] private int poolCount = 8;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private EnemyBehavior _enemyPrefab;
    private PoolMono<EnemyBehavior> enemiesPool;

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
        this.OnWavesChangedEvent?.Invoke(_currentWave);
        this.enemiesPool = new PoolMono<EnemyBehavior>(this._enemyPrefab, this.poolCount, this.transform, this.autoExpand);
        SpawnEnemies(_enemiesNumber);
    }

    public void OnEnemyDeath(GameObject enemy)
    {
        enemies.Remove(enemy);
        this.OnEnemiesCountChangeEvent?.Invoke(enemies.Count);
        if (enemies.Count == 0 && _wavesNumber > 0)
        {
            _enemiesNumber++;
            SpawnEnemies(_enemiesNumber);
        }
    }

    private void SpawnEnemies(int _enemiesToSpawn)
    {
        _wavesNumber--;
        _currentWave++;
        this.OnWavesChangedEvent?.Invoke(_currentWave);
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            var enemyCreated = this.enemiesPool.GetFreeElement();
            enemyCreated.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)];
            enemies.Add(enemyCreated.gameObject);
           // enemies.Add(Instantiate(_enemyPrefab.gameObject, spawnPositions[Random.Range(0, spawnPositions.Length)], _enemyPrefab.transform.rotation));
        }
        this.OnEnemiesCountChangeEvent?.Invoke(enemies.Count);
    }
}
