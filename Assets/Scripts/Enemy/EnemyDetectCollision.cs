using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectCollision : MonoBehaviour
{
    [SerializeField] private EnemyBehavior _enemy;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision found");
        if (collision.gameObject.TryGetComponent<PlayerDetectCollision>(out PlayerDetectCollision player) )//&& _enemy.IsAttacking)
        {
            Debug.Log("Hit player");
            player.ReceiveDamage();
        }

    }
    public void ReceiveShot(Vector3 hitPosition)
    {
        _enemy.ReceiveShot(hitPosition);
    }
}
