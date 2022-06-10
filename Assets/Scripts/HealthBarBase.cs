using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBase : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    protected void OnDamageReceived(float valueAsPercentage)
    {
        _healthBar.fillAmount = valueAsPercentage;
    }
}
