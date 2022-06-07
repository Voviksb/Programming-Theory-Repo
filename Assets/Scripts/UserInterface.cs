using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private TextMeshProUGUI _unitHpText;
    [SerializeField] private TextMeshProUGUI _enemiesText;
    void Start()
    {
       // _waveText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }

    public void UpdateHpText(int unitHp)
    {
        _unitHpText.text = "HP: " + unitHp;
    }
    public void UpdateWaveText(int waveNumber)
    {
        _waveText.text = "Wave: " + waveNumber;
    }
    public void UpdateEnemiesText(int enemiesNumber)
    {
        _enemiesText.text = "Enemies left: " + enemiesNumber;
    }
}
