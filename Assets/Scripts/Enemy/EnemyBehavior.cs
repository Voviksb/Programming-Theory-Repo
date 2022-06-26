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

    public bool isAttacking;

    private Color _origEnemyColor;

    private bool isAlive = true;
    
    private void Awake()
    {
        _origEnemyColor = _meshRenderer.material.color;
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
        _meshRenderer.material.color = _origEnemyColor;
    }

    public int EnemyHp
    {
        get { return _currentHp; }
        private set
        {
            _currentHp = value;
            if (_currentHp <= 0 && isAlive)
            {
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
        if (!isAttacking)
        {
            _enemyNavMeshAgent.destination = _playerTransform.position;
        }
    }

    public override void ReceiveDamage()
    {
        if (isAlive)
        {
            StartCoroutine("DamageFlash");
            EnemyHp -= 10;
        }
    }

    private void EnemyDeath()
    {
        OnDamageReceived(0);
        isAlive = false;
        _enemyNavMeshAgent.isStopped = true;
        _enemyAnimator.SetFloat("UnitHp", 0);
        _meshRenderer.material.color = Color.black;
        EnemiesSpawner.Instance.OnEnemyDeath(this.gameObject);
        StartCoroutine(DeathColorChange(1.5f));
    }

    private IEnumerator DeathColorChange(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.gameObject.SetActive(false);
    }

    private IEnumerator DamageFlash()
    {
        _meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        if (isAlive)
        {
            _meshRenderer.material.color = _origEnemyColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            Attack();
        }
    }
    public override void Attack()
    {
        isAttacking = true;
        _enemyAnimator.SetBool("playerInRange", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            _enemyAnimator.SetBool("playerInRange", false);
            isAttacking = false;
        }
    }
}