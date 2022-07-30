using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidManager : MonoBehaviour
{
   // [SerializeField] private MapSettings _map;
    [SerializeField] private RaidLoadingTransition _raidLoadingTransition;
    [SerializeField] private PlayerBehaviour _player;

    public static RaidManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Raid Manager in the scene");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void StartRaid()
    {
        //InitializeMap();
        SpawnPlayer();
        _raidLoadingTransition.LoadRaid(1);  
    }

    public void InitializeMap()
    {
       // _map.InitializeEscapePositions();
    }

    private void SpawnPlayer()
    {
        _player.GetComponent<Transform>().position = MapSettings.SelectSpawnPosition();
    }
}
