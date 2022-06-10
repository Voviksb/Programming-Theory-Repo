using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBase : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] UnitBehaviour healthBarOwner;
    void Awake()
    {
        healthBarOwner.OnDamageReceivedEvent += OnDamageReceived;
    }

    void OnDestroy()
    {
        healthBarOwner.OnDamageReceivedEvent -= OnDamageReceived;
    }
    protected void OnDamageReceived(float valueAsPercentage)
    {
        _healthBar.fillAmount = valueAsPercentage;
    }
}
