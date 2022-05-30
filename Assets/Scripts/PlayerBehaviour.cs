using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : UnitBehaviour
{
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _verticalInput;
    [SerializeField] [Range(0.0f, 0.5f)] private float _moveSmoothTime = 0.3f;

    private Rigidbody _playerRb;
    private CharacterController _playerController;

    private Vector2 _currentDir = Vector2.zero;
    private Vector2 _currentDirVelocity = Vector2.zero;

    public void PlayerBehavior()
    {
        
    }
    private void Start()
    {
        _unitHp = 100;
        _unitSpeed = 40;
        _playerRb = GetComponent<Rigidbody>();
        _playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        UpdateMovement();
    }

    private void FixedUpdate()
    {
        
     // _playerRb.AddForce(Vector3.forward * _verticalInput * _unitSpeed * Time.deltaTime, ForceMode.VelocityChange);
    } 

    protected override void Attack()
    {
        
    }

    private void UpdateMovement()
    {

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        _currentDir = Vector2.SmoothDamp(_currentDir, targetDir, ref _currentDirVelocity, _moveSmoothTime);

        Vector3 velocity = (transform.forward * _currentDir.y + transform.right * _currentDir.x) * _unitSpeed;

        _playerController.Move(velocity * Time.deltaTime);
        /*_horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * _verticalInput * _unitSpeed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.right * _horizontalInput * _unitSpeed * Time.deltaTime, Space.Self);*/
    }
}
