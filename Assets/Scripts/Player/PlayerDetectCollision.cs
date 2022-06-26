using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectCollision : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _player;
  /*  private void OnCollisionEnter(Collision collision)
    {
        _player.OnCollisionEnter(collision);
    }*/
    public void ReceiveDamage()
    {
        _player.ReceiveDamage();
    }
}
