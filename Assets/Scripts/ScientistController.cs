using System;
using UnityEngine;

public class ScientistController : MonoBehaviour
{
    public PlayerBecher BecherHeld;

    private CharacterController _characterControler;


#pragma warning disable 649

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _gravity = 20.0F;

#pragma warning restore 649
    Vector3 _moveDirection;
    private Animator _animator;
    private Vector2 _lastMovement;

    private void Start()
    {
        _characterControler = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = -Input.GetAxis("Horizontal");
        float vertical = -Input.GetAxis("Vertical");
        HandlingAnimation(horizontal, vertical);


        if (_characterControler.isGrounded)
        {
            _moveDirection = new Vector3(horizontal, 0, vertical);
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= _moveSpeed;

            _lastMovement = new Vector2(horizontal, vertical);
        }
        _moveDirection.y -= _gravity*Time.deltaTime;
        _characterControler.Move(_moveDirection*Time.deltaTime);
    }


    void HandlingAnimation(float horizontal, float vertical)
    {
        bool noMovementInput = Math.Abs(horizontal) < 0.001f && Math.Abs(vertical) < 0.001f;
        _animator.SetBool(CharacterAnimationParams.IsStandingStill.ToString(),
            noMovementInput);
        //_animator.SetFloat(CharacterAnimationParams.Horizontal.ToString(), horizontal);
        //_animator.SetFloat(CharacterAnimationParams.Vertical.ToString(), vertical);


        if (Math.Sign(_lastMovement.x) != Math.Sign(horizontal))

        {
            if (Math.Sign(horizontal) == 1)
                _animator.SetTrigger(CharacterAnimationParams.StartedWalkingRight.ToString());

            if (Math.Sign(horizontal) == -1)
                _animator.SetTrigger(CharacterAnimationParams.StartedWalkingLeft.ToString());
        }
        else if (Math.Sign(_lastMovement.y) != Math.Sign(vertical))
        {
            if (Math.Sign(vertical) == 1)
                _animator.SetTrigger(CharacterAnimationParams.StartedWalkingFront.ToString());

            if (Math.Sign(vertical) == -1)

                _animator.SetTrigger(CharacterAnimationParams.StartedWalkingBack.ToString());
        }


        if (noMovementInput && _lastMovement != Vector2.zero)
        {
            _animator.SetTrigger(CharacterAnimationParams.StoppedMoving.ToString());
        }
    }

    enum CharacterAnimationParams
    {
        IsStandingStill,
        StartedWalkingLeft,
        StartedWalkingRight,
        StartedWalkingFront,
        StartedWalkingBack,
        StoppedMoving,
        Horizontal,
        Vertical
    }
}