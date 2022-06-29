using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GravityHandler
{
    private static float _currentAttractionCharacter = 0f;
    private static float _gravityForce = 20f;

    public static float GravityHandling(CharacterController characterController)
    {
        if (!characterController.isGrounded)
        {
            return _currentAttractionCharacter -= _gravityForce * Time.deltaTime;
        }
        else
        {
            return _currentAttractionCharacter = 0;
        }
    }
}
