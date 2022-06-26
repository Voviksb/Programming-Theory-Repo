using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickForMovement : JoystickHandler
{

    private void Update()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
        {
            PlayerController.MovePlayer(new Vector3(_inputVector.x, 0, _inputVector.y));

            if(!Player.IsAttacking)
                PlayerController.RotatePlayer(new Vector3(_inputVector.x, 0, _inputVector.y));
        }
        else
        {
            PlayerController.MovePlayer(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

            if (!Player.IsAttacking)
                PlayerController.RotatePlayer(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        }
    }
}
