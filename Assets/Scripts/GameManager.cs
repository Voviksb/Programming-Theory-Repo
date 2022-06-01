using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int _enemiesNumber;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] Vector3[] spawnPositions = new Vector3[5];

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
        SpawnEnemies(_enemiesNumber);
    }

    private void SpawnEnemies(int _enemiesNumber)
    {
        for (int i = 0; i < _enemiesNumber; i++)
        {
            Instantiate(_enemyPrefab, spawnPositions[Random.Range(0, spawnPositions.Length)], _enemyPrefab.transform.rotation);
        }
    }

}
