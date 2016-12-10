using System;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    private Rigidbody _rigidbody;

    float _currentSpeed;
#pragma warning disable 649
    [SerializeField]
    float _maxMoveSpeed;

    [SerializeField]
    float _moveSpeed;
#pragma warning restore 649


    void Start()
    {

        _rigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        _currentSpeed = _rigidbody.velocity.sqrMagnitude;

        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");

        bool moveRequested = Math.Abs(axisV) + Math.Abs(axisH) > 0.1f;

        if (_currentSpeed < _maxMoveSpeed)
        {
            Move(axisH, axisV);
        }
        if (!moveRequested)
        {
            _rigidbody.velocity = Vector3.zero;
        }

    }

    void Move(float x, float z)
    {

        Vector3 direction = new Vector3(-x * _moveSpeed, 0, -z * _moveSpeed);
        _rigidbody.AddForce(direction);

    }
}
