using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _verticalInput;
    [SerializeField] [Range(0.0f, 0.5f)] private float _moveSmoothTime = 0.3f;

    private CharacterController _playerController;

    private Vector2 _currentDir = Vector2.zero;
    private Vector2 _currentDirVelocity = Vector2.zero;
    private PlayerBehaviour _playerBehaviour;

    private void Start()
    {
        _playerController = GetComponent<CharacterController>();
        _playerBehaviour = GetComponent<PlayerBehaviour>();
    }

    private void Update()
    {
        UpdateMovement();
        DetectAttack();
    }

    private void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        _currentDir = Vector2.SmoothDamp(_currentDir, targetDir, ref _currentDirVelocity, _moveSmoothTime);

        Vector3 velocity = (transform.forward * _currentDir.y + transform.right * _currentDir.x) * _playerBehaviour.UnitSpeed;

        _playerController.Move(velocity * Time.deltaTime);
    }

    private void DetectAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerBehaviour.Attack();
        }
    }
}
