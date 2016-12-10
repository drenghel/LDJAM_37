using UnityEngine;

public class ScientistController : MonoBehaviour
{
    private CharacterController _characterControler;


#pragma warning disable 649

    [SerializeField]
    private float _moveSpeed;
    [SerializeField]

    private float _gravity = 20.0F;

#pragma warning restore 649
    Vector3 _moveDirection;


    private void Start()
    {
        _characterControler = GetComponent<CharacterController>();
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            _moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= _moveSpeed;
            //if (Input.GetButton("Jump"))
            //    _moveDirection.y = jumpSpeed;
        }
        _moveDirection.y -= _gravity * Time.deltaTime;
        controller.Move(_moveDirection * Time.deltaTime);
    }
}