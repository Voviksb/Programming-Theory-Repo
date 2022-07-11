using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : HealthBarBase
{
    [SerializeField] PlayerBehaviour _player;

    void Awake()
    {
        _player = GameObject.FindWithTag("player").GetComponent<PlayerBehaviour>();
        healthBarOwner = _player;
       // Debug.Log(healthBarOwner.name + "Initialized hpbar in child class");
    }

    void OnDestroy()
    {
    }
}
