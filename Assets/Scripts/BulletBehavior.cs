using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy))
        {
            enemy?.ReceiveDamage();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3f);
        }
    }
}
