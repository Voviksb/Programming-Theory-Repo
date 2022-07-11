using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : UnitBehaviour
{
    
    [SerializeField] private Weapon _weapon;
    [SerializeField] private bool _isAttacking = false;

    [SerializeField] private Animator _playerAnimator;
    

    public bool IsAttacking
    {
        get
        {
            return _isAttacking;
        }
        set
        {
            _isAttacking = value;
            if (_isAttacking)
            {
                _playerAnimator.SetBool("isShooting", true);
            }
            else
            {
                _playerAnimator.SetBool("isShooting", false);
            }
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _maxHp = 100;
        _currentHp = _maxHp;
        _unitSpeed = 40;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _weapon.Shoot();
        }
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
        _weapon.Shoot();
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
}
