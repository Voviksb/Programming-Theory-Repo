using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        _unitHp = 50;
        _unitSpeed = 15;
        _enemyNavMeshAgent.speed = _unitSpeed;
        _playerTransform = GameObject.FindWithTag("player").GetComponent<Transform>();
        _origEnemyColor = _meshRenderer.material.color;
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
        CheckDamage(collision);
    }

    private void CheckDamage(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            if (isAlive)
            {
                _unitHp -= 10;
                StartCoroutine(DamageFlash());
                Debug.Log(_unitHp);
                CheckDeath();
            }
        }
    }

    private void CheckDeath()
    {
        if (_unitHp <= 0 && isAlive)
        {
            isAlive = false;
            _enemyNavMeshAgent.isStopped = true;
            _enemyAnimator.SetFloat("UnitHp", 0);
            _enemyRigidbody.constraints = RigidbodyConstraints.FreezeAll;

            _meshRenderer.material.color = Color.black;
            Debug.Log("Color is black");

            Destroy(gameObject, 1.7f);
        }
    }

    private IEnumerator DamageFlash()
    {
        _meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        if (isAlive)
        {
            _meshRenderer.material.color = _origEnemyColor;
        }
        Debug.Log("Color is back");
    }
}
