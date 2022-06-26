using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : UnitBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _weaponMuzzlePos;
    [SerializeField] private float _shootingCooldown = 0f;
    [SerializeField] private float _fireRate = 0.11f;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private AudioSource _shootingSource;
    public bool isAttacking = false;

    private void Start()
    {
        _maxHp = 100;
        _currentHp = _maxHp;
        _unitSpeed = 40;
    }

    private void Update()
    {
        if(_shootingCooldown > 0)
        {
            _shootingCooldown -= Time.deltaTime;
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
        isAttacking = true;
        if (_shootingCooldown <= 0)
        {
            _shootingSource.PlayOneShot(_shootingSource.clip);
            _shootingCooldown = _fireRate;
            GameObject bullet = Instantiate(_bulletPrefab, _weaponMuzzlePos.position, _weaponMuzzlePos.transform.rotation) as GameObject;
            _muzzleFlash.Play();
        }
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
