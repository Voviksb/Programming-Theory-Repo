using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : UnitBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _weaponMuzzlePos;
    private void Start()
    {
        _unitHp = 100;
        _unitSpeed = 40;
    }

    public int UnitSpeed
    {
        get { 
            return _unitSpeed;
        }
    }
    private void Update()
    {

    }
    public override void Attack()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _weaponMuzzlePos.position, _weaponMuzzlePos.transform.rotation) as GameObject;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = _weaponMuzzlePos.transform.forward * 250f;
        Destroy(bullet, 3f);
    }
}
