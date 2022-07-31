using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccount : MonoBehaviour, IDataPersistence
{
    // [SerializeField] private PlayerAccountData _playerAccountData;
    [SerializeField] private string _playerID;
    [SerializeField] private string _playerName;
    [SerializeField] private bool _isVIP;

    public static PlayerAccount Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Player in the scene");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {

    }

    public void LoadData(GameData data)
    {
        //  _playerID = data.playerID; 
        _playerID = data.playerAccountData.playerID;
        _playerName = data.playerAccountData.playerName;
        _isVIP = data.playerAccountData.isVIP;
    }

    public void SaveData(GameData data)
    {
        //data.playerID = _playerID;
        data.playerAccountData.playerID = _playerID;
        data.playerAccountData.playerName = _playerName;
        data.playerAccountData.isVIP = _isVIP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerID = System.Guid.NewGuid().ToString();
            DataPersistenceManager.Instance.SaveGame();  
        }
    }
}
