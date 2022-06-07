using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBehaviour : MonoBehaviour
{
    [SerializeField] protected int _unitHp;
    [SerializeField] protected int _unitSpeed;
    public abstract void Attack();
    public abstract void ReceiveDamage();
}
