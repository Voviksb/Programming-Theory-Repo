using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _magazineCapacity = 30;
    [SerializeField] private int _currentMagazine;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _shootingCooldown = 0f;
    [SerializeField] private float _fireRate = 0.11f;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private Transform _weaponMuzzlePos;
    [SerializeField] private AudioSource _shootingSource;
    
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private bool isReloading = false;
    [SerializeField] private AudioClip[] _audioClips;


    private void Start()
    {
        _currentMagazine = _magazineCapacity;
        _reloadTime = _audioClips[1].length;
    }

    private void Update()
    {
        if (_shootingCooldown > 0)
        {
            _shootingCooldown -= Time.deltaTime;
        }
    }
    public void Shoot()
    {
        if (_shootingCooldown <= 0 && _currentMagazine > 0)
        {
            _shootingSource.PlayOneShot(_audioClips[0]);
            _shootingCooldown = _fireRate;
            GameObject bullet = Instantiate(_bulletPrefab, _weaponMuzzlePos.position, _weaponMuzzlePos.transform.rotation) as GameObject;
            _currentMagazine--;
            _muzzleFlash.Play();
        }
        else if(_currentMagazine == 0 && !isReloading)
        {
            isReloading = true;
            _shootingCooldown = _fireRate;
            _shootingSource.PlayOneShot(_audioClips[1]);
            StartCoroutine("ReloadWeapon", _reloadTime);
        }
    }

    private IEnumerator ReloadWeapon(float reloadTime)
    {   
        yield return new WaitForSeconds(reloadTime);
        _currentMagazine = _magazineCapacity;
        isReloading = false;
    }
}
