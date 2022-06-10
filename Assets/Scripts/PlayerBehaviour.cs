using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : UnitBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _weaponMuzzlePos;
    private void Start()
    {
        _maxHp = 100;
        _currentHp = _maxHp;
       // GameManager.Instance.UserInterface.UpdateHpText(_unitHp);
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
                base.OnDamageReceive(0);
            }
            else
            {
                float _currentHpAsPercentage = (float)_currentHp / _maxHp;
                base.OnDamageReceive(_currentHpAsPercentage);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReceiveDamage();
        }
    }
    public override void Attack()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _weaponMuzzlePos.position, _weaponMuzzlePos.transform.rotation) as GameObject;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = _weaponMuzzlePos.transform.forward * 250f;
        Destroy(bullet, 3f);
    }

    public override void ReceiveDamage()
    {
        UnitHP -= 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
