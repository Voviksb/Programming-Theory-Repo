using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _verticalInput;
    [SerializeField] [Range(0.0f, 0.5f)] private float _moveSmoothTime = 0.3f;

    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotateSpeed = 10f;

    [SerializeField] private Animator _playerAnimator;



    public bool isMoving = false;

    private CharacterController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_playerController.velocity.magnitude < 1)
        {
            isMoving = false;
            _playerAnimator.SetBool("isMoving", isMoving);
        }
    }

    public void MovePlayer(Vector3 moveDirection)
    {
        isMoving = true;
        _playerAnimator.SetBool("isMoving", isMoving);
        moveDirection = moveDirection * _moveSpeed;
        moveDirection.y = GravityHandler.GravityHandling(_playerController);
        _playerController.Move(moveDirection * Time.deltaTime);
    }

    public void RotatePlayer(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);

            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
