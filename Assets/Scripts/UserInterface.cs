using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private TextMeshProUGUI _unitHpText;
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
}
