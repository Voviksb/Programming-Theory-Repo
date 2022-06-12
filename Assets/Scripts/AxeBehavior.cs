using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBehavior : MonoBehaviour
{
    public EnemyBehavior enemyBehavior;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player) && enemyBehavior.isAtacking)
        {
            Debug.Log("Damage player");
        }
    }
}
