using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletRb; 

    private void Start()
    {
        _bulletRb.velocity = transform.forward * 120f;
        Destroy(this, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
     //   Debug.Log("Collided with smth"+ collision.gameObject.name);
        if (collision.gameObject.TryGetComponent<EnemyBehavior>(out EnemyBehavior enemy))
        {
            Debug.Log("Collided with enemy");
            enemy?.ReceiveShot(transform.position);    
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3f);
        }
    }
}
