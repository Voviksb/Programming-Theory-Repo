using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _raidTimeLeft;
    [SerializeField] private EnemiesSpawner _levelSpawner;
    [SerializeField] private WavesHandler _wavesHandler;
    [SerializeField] private Raid _raid;
    [SerializeField] private ActivePointsText _activePointsText;

    private void Awake()
    {
        _raid.OnTimerCountChangedEvent += OnRaidTimerChanged;
    }

    public void OnRaidTimerChanged(string str)
    {
        _raidTimeLeft.text = str;
    }

    private void OnDisable()
    {
        _raid.OnTimerCountChangedEvent -= OnRaidTimerChanged;
    }
}
