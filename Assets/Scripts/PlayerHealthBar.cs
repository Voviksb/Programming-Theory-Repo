using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : HealthBarBase
{
    [SerializeField] PlayerBehaviour player;

    void Awake()
    {
        player.OnDamageReceiveEvent += base.OnDamageReceived;
    }

    void OnDestroy()
    {
        player.OnDamageReceiveEvent -= base.OnDamageReceived;
    }
}
