using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyBehavior : UnitBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;
    [SerializeField] private NavMeshAgent _enemyNavMeshAgent;
    [SerializeField] private ParticleSystem _bloodFlash;
    [SerializeField] private AudioSource _enemySource;
    [SerializeField] private Rigidbody _enemyRb;
    [SerializeField] private bool _isAttacking = false;
    AnimatorClipInfo[] animatorinfo;

    public bool IsAttacking
    {
        get
        {
            return _isAttacking;
        }
        set
        {
            _isAttacking = value;
        }
    }

    [SerializeField] private bool isAlive = true;
    
    private void Awake()
    {
        _maxHp = 100;
        _unitSpeed = 15;
        _enemyNavMeshAgent.speed = _unitSpeed;
        _playerTransform = GameObject.FindWithTag("player").GetComponent<Transform>();
    }
    private void OnEnable()
    {
        _currentHp = _maxHp;
        OnDamageReceived(1);
        isAlive = true;
        _enemyRb.detectCollisions = true;
        _enemyRb.isKinematic = false;
    }

    public int EnemyHp
    {
        get { return _currentHp; }
        private set
        {
            _currentHp = value;
            if (_currentHp <= 0 && isAlive)
            {
                OnDamageReceived(0);
                EnemyDeath();
            }
            else
            {
                float _currentHpAsPercentage = (float)_currentHp / _maxHp;
                OnDamageReceived(_currentHpAsPercentage);
            }
        }
    }

    private void Update()
    {
        if (!_isAttacking)
        {
            _enemyNavMeshAgent.destination = _playerTransform.position;
        }
        else
        {
            _enemyNavMeshAgent.velocity = Vector3.zero;
            _enemyNavMeshAgent.ResetPath();
            //  _enemyNavMeshAgent.destination = transform.position;
        }
    }

    public override void ReceiveDamage() 
    {
        if (isAlive)
        {
            EnemyHp -= 10;
        }
    }
    public void ReceiveShot(Vector3 hitPosition)
    {
        if (isAlive)
        {
            _enemySource.PlayOneShot(_enemySource.clip);
            _bloodFlash.transform.position = hitPosition;
            _bloodFlash.Play();
            ReceiveDamage();
        }
    }
    private void EnemyDeath()
    {   
        isAlive = false;
        _enemyRb.detectCollisions = false;
        _enemyRb.isKinematic = true;
        _enemyNavMeshAgent.isStopped = true;
        _enemyAnimator.SetFloat("UnitHp", 0);
        EnemiesSpawner.Instance.OnEnemyDeath(this.gameObject);
        StartCoroutine(DestroyOnDeath(1.5f));
    }

    private IEnumerator DestroyOnDeath(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.gameObject.SetActive(false);
    }

    public override void Attack()
    {
       // _enemyRb.isKinematic = true;
        _isAttacking = true;
        _enemyAnimator.SetBool("playerInRange", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            Attack();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            _enemyAnimator.SetBool("playerInRange", false);
            _isAttacking = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player) && _isAttacking)
        {
            player.ReceiveDamage();
            _isAttacking = false;
        }
    }
}