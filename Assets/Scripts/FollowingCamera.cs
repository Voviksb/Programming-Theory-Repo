using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [Header("Object for following")]
    [SerializeField] private GameObject _player;

    [Header("Camera properties")]
    [SerializeField] private float _returnSpeed;
    [SerializeField] private float _height;
    [SerializeField] private float _rearDistance;

    private Vector3 _currentVector;

    private void Awake()
    {
        _player = GameObject.FindWithTag("player");
    }


    void Start()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + _height, _player.transform.position.z - _rearDistance);
        transform.rotation = Quaternion.LookRotation(_player.transform.position - transform.position);

    }

    void Update()
    {
        CameraMove();
    }

    void CameraMove()
    {
        _currentVector = new Vector3(_player.transform.position.x, _player.transform.position.y + _height, _player.transform.position.z - _rearDistance);
        transform.position = Vector3.Lerp(transform.position, _currentVector, _returnSpeed * Time.deltaTime);
    }
}