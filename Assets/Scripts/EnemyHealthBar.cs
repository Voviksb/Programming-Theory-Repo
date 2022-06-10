using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : HealthBarBase
{
    [SerializeField] EnemyBehavior enemy;

    void Awake()
    {
        enemy.OnDamageReceiveEvent += base.OnDamageReceived;
    }

    void OnDestroy()
    {
        enemy.OnDamageReceiveEvent -= base.OnDamageReceived;
    }
    private void LateUpdate()
    {
        transform.LookAt(new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z));
    }
}
