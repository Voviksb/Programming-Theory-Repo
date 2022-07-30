using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WavesHandler : MonoBehaviour
{
    [SerializeField] private int _wavesLeft = 3;
    [SerializeField] private int _enemiesToSpawn = 3;
    [SerializeField] private int _currentWave = 1;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private UserInterface _userInterface;

    public delegate void WavesHandlerEvent(int value);
    public event WavesHandlerEvent OnWavesChangedEvent;

    private void OnEnable()
    {
        _enemiesSpawner.OnAllEnemiesDeadEvent += OnWaveFinished;
    }

    private void OnDisable()
    {
        _enemiesSpawner.OnAllEnemiesDeadEvent -= OnWaveFinished;
    }

    private void Start()
    {
        _enemiesSpawner.SpawnEnemies(_enemiesToSpawn);
        this.OnWavesChangedEvent?.Invoke(_currentWave);
    }

    private void OnWaveFinished()
    {
        if (_wavesLeft > 0)
        {
            StartCoroutine(WaitNextWave(3));
        }
    }

    private void StartNextWave()
    {
        _wavesLeft--;
        _enemiesToSpawn++;
        _enemiesSpawner.SpawnEnemies(_enemiesToSpawn);
        _currentWave++;
        this.OnWavesChangedEvent?.Invoke(_currentWave);
    }

    private IEnumerator WaitNextWave(int secs)
    {
        for (int i = 0; i < secs; i++)
        {
            yield return new WaitForSeconds(1);
        }
        StartNextWave();
        yield break;
    }
}
