using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickForAttack : JoystickHandler
{
    private void Update()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
        {
            Player.Attack();
            PlayerController.RotatePlayer(new Vector3(_inputVector.x, 0, _inputVector.y));
        }
        else
        {
            Player.IsAttacking = false;
        }
    }
}