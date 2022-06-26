using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : UnitBehaviour
{
    
    [SerializeField] private Weapon weapon;


    private void Start()
    {
        _maxHp = 100;
        _currentHp = _maxHp;
        _unitSpeed = 40;
    }

    public int UnitSpeed
    {
        get { 
            return _unitSpeed;
        }
    }

    public int UnitHP
    {
        get
        {
            return _currentHp;
        }
        private set
        {
            _currentHp = value;
            if (_currentHp <= 0)
            {
               Debug.Log("Player dead");
            }
            UpdateHpBar();
        }
    }
    public override void Attack()
    {
        IsAttacking = true;
        weapon.Shoot();
    }
    public override void ReceiveDamage()
    {
        UnitHP -= 10;
    }

    private void UpdateHpBar()
    {
        if (_currentHp <= 0)
        {
            base.OnDamageReceived(0);
        }
        else
        {
             float _currentHpAsPercentage = (float)_currentHp / _maxHp;
            base.OnDamageReceived(_currentHpAsPercentage);
        }
    }

   /* public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<EnemyDetectCollision>(out EnemyDetectCollision enemy) && enemy._enemy.IsAttacking)
        {
            ReceiveDamage();
        }
    }*/
}
