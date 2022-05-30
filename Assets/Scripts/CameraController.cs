using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerCamera = null;
    [SerializeField] private float mouseSensitivity = 3.5f;
    [SerializeField] [Range(0.0f, 0.5f)] private float _mouseSmoothTime = 0.3f;

    [SerializeField] bool lockCursor = true;

    private float _cameraPitch = 0.0f;
    private Vector2 _currentMouseDelta = Vector2.zero;
    private Vector2 _currentMouseDeltaVelocity = Vector2.zero;

    private void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    private void Update()
    {
        UpdateMouseLook();
    }


    private void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        _currentMouseDelta = Vector2.SmoothDamp(_currentMouseDelta, targetMouseDelta, ref _currentMouseDeltaVelocity, _mouseSmoothTime);

        _cameraPitch -= _currentMouseDelta.y * mouseSensitivity;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -90.0f, 90f);

        playerCamera.localEulerAngles = Vector3.right * _cameraPitch;
        transform.Rotate(Vector3.up * _currentMouseDelta.x * mouseSensitivity);
    }
}
