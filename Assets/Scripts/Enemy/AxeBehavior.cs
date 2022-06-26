using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBehavior : MonoBehaviour
{
    public EnemyBehavior enemyBehavior;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player) && enemyBehavior.IsAttacking) 
        {
            player.ReceiveDamage();
        }
    }
}
