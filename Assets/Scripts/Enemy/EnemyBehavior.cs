using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyBehavior : UnitBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private PlayerBehaviour _player;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;
    [SerializeField] private NavMeshAgent _enemyNavMeshAgent;
    [SerializeField] private ParticleSystem _bloodFlash;
    [SerializeField] private AudioSource _enemySource;
    AnimatorClipInfo[] animatorinfo;

    [SerializeField] private bool isAlive = true;
    
    private void Awake()
    {
        _maxHp = 100;
        _unitSpeed = 15;
        _enemyNavMeshAgent.speed = _unitSpeed;
        _player = GameObject.FindWithTag("player").GetComponent<PlayerBehaviour>();
        _playerTransform = _player.GetComponent<Transform>();
    }
    private void OnEnable()
    {
        _currentHp = _maxHp;
        OnDamageReceived(1);
        isAlive = true;
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
   // (_playerTransform.position - transform.position).magnitude > 5f
    private void Update()
    {
        if (!IsAttacking)
        {
         //   _enemyNavMeshAgent.isStopped = false;
            _enemyNavMeshAgent.destination = _playerTransform.position;
        }
        else
        {
            _enemyNavMeshAgent.destination = transform.position;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            Attack();
        }
    }
    public override void Attack()
    {
        this.IsAttacking = true;
        _enemyAnimator.SetBool("playerInRange", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            _enemyAnimator.SetBool("playerInRange", false);
            this.IsAttacking = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision detected on child");
    }
}