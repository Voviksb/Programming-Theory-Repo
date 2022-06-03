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

   // public delegate void AllEnemiesDead();
  //  public static event AllEnemiesDead OnDead;

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
       // SpawnEnemies(_enemiesNumber);
    }

    private void Update()
    {
        if(enemies.Count == 0 && _wavesNumber > 0)
        {
            SpawnEnemies(_enemiesNumber);
        }
    }

    private void SpawnEnemies(int _enemiesToSpawn)
    {
        _currentWave++;
        userInterface.UpdateWaveText(_currentWave);
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            enemies.Add(Instantiate(_enemyPrefab, spawnPositions[Random.Range(0, spawnPositions.Length)], _enemyPrefab.transform.rotation));
        }
        Debug.Log(enemies.Count);
        _enemiesNumber++;
        _wavesNumber--;
    }
}
