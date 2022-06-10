using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UnitBehaviour : MonoBehaviour
{
    [SerializeField] protected int _currentHp;
    [SerializeField] protected int _unitSpeed;
    [SerializeField] protected int _maxHp;
    public event Action<float> OnDamageReceivedEvent;
    public abstract void Attack();
    public abstract void ReceiveDamage();

    protected void OnDamageReceived(float valueAsPercentage)
    {
        OnDamageReceivedEvent?.Invoke(valueAsPercentage);
    }
}
