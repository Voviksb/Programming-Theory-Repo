using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int _enemiesNumber;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] Vector3[] spawnPositions = new Vector3[5];
    [SerializeField] private int _wavesNumber;
    [SerializeField] private int _currentWave = 0;
    [SerializeField] private UserInterface userInterface;

    /* public delegate void WaveHandler(int _currentWave);
     public event WaveHandler OnWavesChangedEvent;

     public delegate void EnemyCountHandler(int enemiesCount);
     public event EnemyCountHandler OnEnemiesCountChangeEvent;*/

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

    public UserInterface UserInterface
    {
        get { return userInterface; }
    }

    private void Start()
    {
        this.OnWavesChangedEvent?.Invoke(_currentWave);
        SpawnEnemies(_enemiesNumber);
    }

    private void Update()
    {
        
    }

    public void OnEnemyDeath(GameObject enemy)
    {
        enemies.Remove(enemy);
        this.OnEnemiesCountChangeEvent?.Invoke(enemies.Count);
        if (enemies.Count == 0 && _wavesNumber > 0)
        {
            SpawnEnemies(_enemiesNumber);
        }
    }

    private void SpawnEnemies(int _enemiesToSpawn)
    {
        _currentWave++;
        this.OnWavesChangedEvent?.Invoke(_currentWave);
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            enemies.Add(Instantiate(_enemyPrefab, spawnPositions[Random.Range(0, spawnPositions.Length)], _enemyPrefab.transform.rotation));
        }
        this.OnEnemiesCountChangeEvent?.Invoke(enemies.Count);
        _enemiesNumber++;
        _wavesNumber--;
    }
}
