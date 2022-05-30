using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBehaviour : MonoBehaviour
{
    protected int _unitHp;
    protected int _unitSpeed;
    protected abstract void Attack();
}
