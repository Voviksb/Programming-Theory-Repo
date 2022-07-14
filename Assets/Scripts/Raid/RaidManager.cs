using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidManager : MonoBehaviour
{
    [SerializeField] private MapSettings _map;
    [SerializeField] private RaidLoadingTransition _raidLoadingTransition;
    [SerializeField] private PlayerBehaviour _player;
        
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void StartRaid()
    {    
        _raidLoadingTransition.LoadRaid(1);
        InitializeMap();
        SpawnPlayer();
    }

    public void InitializeMap()
    {
        _map.InitializeEscapePositions();
    }

    private void SpawnPlayer()
    {
        _player.GetComponent<Transform>().position = _map.SelectSpawnPosition();
    }
}
