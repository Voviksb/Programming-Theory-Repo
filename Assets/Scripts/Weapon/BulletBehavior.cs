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
        if(collision.gameObject.TryGetComponent<EnemyDetectCollision>(out EnemyDetectCollision enemy))
        {
            enemy?.ReceiveShot(transform.position);    
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3f);
        }
    }

    private void Update()
    {
       // this.gameObject.transform.Translate(transform.forward * 10f);
    }
}
