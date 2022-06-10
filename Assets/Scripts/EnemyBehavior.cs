using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyBehavior : UnitBehaviour
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;
    [SerializeField] private Rigidbody _enemyRigidbody;
    private Color _origEnemyColor;

    

    private bool isAlive = true;
    private NavMeshAgent _enemyNavMeshAgent; 

    private void Awake()
    {
        _enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        _maxHp = 100;
        _currentHp = _maxHp;
        _unitSpeed = 15;
        _enemyNavMeshAgent.speed = _unitSpeed;
        _playerTransform = GameObject.FindWithTag("player").GetComponent<Transform>();
        _origEnemyColor = _meshRenderer.material.color;
    }

    public int EnemyHp
    {
        get { return _currentHp;}
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
                base.OnDamageReceive(_currentHpAsPercentage);
            }
        }
    }

    private void Update()
    {
        _enemyNavMeshAgent.destination = _playerTransform.position;
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            ReceiveDamage();
        }
    }
*/
    public override void ReceiveDamage() 
    {
            if (isAlive)
            {
                StartCoroutine(DamageFlash());
                EnemyHp -= 20;
              //  Debug.Log(_unitHp);
            }
    }

    private void EnemyDeath()
    {
            GameManager.Instance.OnEnemyDeath(this.gameObject);
            base.OnDamageReceive(0);
            // OnDamageReceiveEvent?.Invoke(0);
            isAlive = false;
            _enemyNavMeshAgent.isStopped = true;
            _enemyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _enemyAnimator.SetFloat("UnitHp", 0); 
            _meshRenderer.material.color = Color.black;
            //Debug.Log("Color is black");
            Destroy(gameObject, 1.7f);
    }

    private IEnumerator DamageFlash()
    {
        _meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        if (isAlive)
        {
            _meshRenderer.material.color = _origEnemyColor;
        }
        //Debug.Log("Color is back");
    }
}