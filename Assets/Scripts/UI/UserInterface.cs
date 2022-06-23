using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private TextMeshProUGUI _enemiesText;

    private void Awake()
    {
        LevelSpawner.Instance.OnWavesChangedEvent += OnWavesChanged;
        LevelSpawner.Instance.OnEnemiesCountChangeEvent += OnEnemiesCountChange;
    }

    private void OnEnemiesCountChange(int enemiesCount)
    {
        _enemiesText.text = "Enemies left: " + enemiesCount;
    }

    private void OnWavesChanged(int waveNumber)
    {
        _waveText.text = "Wave: " + waveNumber;
    }

    private void OnDisable()
    {
        LevelSpawner.Instance.OnWavesChangedEvent -= OnWavesChanged;
        LevelSpawner.Instance.OnEnemiesCountChangeEvent -= OnEnemiesCountChange;
    }
}
