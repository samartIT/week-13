using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 5.0f;
    private CharacterController _charCtrl;
    private Animator _animator;

    // Jump
    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;
    private float _vertSpeed;
    private ControllerColliderHit _contact;

    private void Start()
    {
        _charCtrl = GetComponent<CharacterController>();
        _vertSpeed = minFall;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 movement = Vector3.zero;

        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        if(horInput != 0 || verInput != 0)
        {
            movement.x = horInput * moveSpeed;
            movement.z = verInput * moveSpeed;

            movement = Vector3.ClampMagnitude(movement, moveSpeed);

            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);

            target.rotation = tmp;
            //transform.rotation = Quaternion.LookRotation(movement);
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotationSpeed * Time.deltaTime);
        }

        _animator.SetFloat("Speed", movement.sqrMagnitude);

        // Jump begin
        print(_charCtrl.isGrounded);
        if (_charCtrl.isGrounded) // check if player on ground
        {
            if (Input.GetButtonDown("Jump")) {         
                _vertSpeed = jumpSpeed;  // set jump force if press "jump"
                _animator.SetBool("Jumping", true);
            } else {
                _vertSpeed = minFall;    // set jump force to fall
                _animator.SetBool("Jumping", false);
            }            
        } else { // if not in Jump state
            _vertSpeed += gravity * 5 * Time.deltaTime; // drag player to ground
            if (_vertSpeed < terminalVelocity) {
                _vertSpeed = terminalVelocity;
            }
        }
        movement.y = _vertSpeed;        
        // Jump end


        movement *= Time.deltaTime;
        _charCtrl.Move(movement);
    }
}
