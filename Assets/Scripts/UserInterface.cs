using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
   // private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private TextMeshProUGUI _unitHpText;
    [SerializeField] private TextMeshProUGUI _enemiesText;

    /*public UserInterface(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.gameManager.OnWavesChangedEvent += OnWavesChanged;
    }*/

    private void Awake()
    {
        GameManager.Instance.OnWavesChangedEvent += OnWavesChanged;
        GameManager.Instance.OnEnemiesCountChangeEvent += OnEnemiesCountChange;
    }

    void Update()
    {

    }

    public void UpdateHpText(int unitHp)
    {
        _unitHpText.text = "HP: " + unitHp;
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
        GameManager.Instance.OnWavesChangedEvent -= OnWavesChanged;
        GameManager.Instance.OnEnemiesCountChangeEvent -= OnEnemiesCountChange;
    }
}
