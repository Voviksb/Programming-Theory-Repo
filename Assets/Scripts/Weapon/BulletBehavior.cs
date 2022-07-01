using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletRb;
    [SerializeField] private ParticleSystem _hitSmoke;
    [SerializeField] private MeshRenderer _bulletMesh;
  //  [SerializeField] private GameObject _bulletObj;

    private void Start()
    {
       // _bulletObj.GetComponentInChildren<BulletPrefab>();
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
            _bulletMesh.enabled = false;
            _bulletRb.isKinematic = true;
            _bulletRb.detectCollisions = false;
            //    _bulletObj.SetActive(false);
            //this.gameObject.SetActive(false);
            _hitSmoke.Play();
            Destroy(gameObject, 3f);
        }
    }
}
