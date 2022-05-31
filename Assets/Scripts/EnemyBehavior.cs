using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : UnitBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private NavMeshAgent _enemyNavMeshAgent;
    [SerializeField] private Animator _enemyAnimator;

    private void Awake()
    {
        _enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _unitHp = 50;
        _unitSpeed = 15;
        _enemyNavMeshAgent.speed = _unitSpeed;
    }

    private void Update()
    {
        _enemyNavMeshAgent.destination = _playerTransform.position;
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            _unitHp -= 10;
            Debug.Log(_unitHp);
        };

        if (_unitHp <= 0)
        {
            _enemyNavMeshAgent.isStopped = true;
            _enemyAnimator.SetFloat("UnitHp", 0);
        }
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
