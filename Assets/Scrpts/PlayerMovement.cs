using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCoolddown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

   /* [Header("Ladder")]
    public bool onLadder;
    public float LadderVerticalSpeed;*/

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    private Vector3 newVelocity;



    Vector3 moveDirection;

    Rigidbody rb;



    public MovementState state;

    public enum MovementState
    {
        crouching,
        freeze,
        unlimited,
    }


    /*public bool freeze;
    public bool unlimited;*/

    public bool restricted;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        startYScale = transform.localScale.y;

        //newVelocity
        //newVelocity = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        //ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        Debug.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.2f), Color.red);

        MyInput();
        SpeedControl();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        /*if (onLadder)
        {
            Vector3 newVelocity;
            newVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            //rb.AddForce(Vector3.up * 9.81f, ForceMode.VelocityChange); 
            rb.useGravity = false;
            if (Input.GetKey(jumpKey))
            {
                newVelocity.y += LadderVerticalSpeed;
            }
            if (Input.GetKey(crouchKey))
            {
                newVelocity.y = LadderVerticalSpeed;
            }
        } */
       // else
        {
            rb.useGravity = true;
            //when to jump
            if (Input.GetKey(jumpKey) && readyToJump && grounded)
            {
                readyToJump = false;

                Jump();

                Invoke(nameof(ResetJump), jumpCoolddown);
            }

        }

        //Start crouch
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        //Stop crouch
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }


    private void MovePlayer()
    {
        if (restricted) return;

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if(grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 2f * airMultiplier, ForceMode.Force);
    }


    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }


    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    private void StateHandler()
    {
        //Mode - Crouching
        if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }

        //Mode - Freeze
        /*if (freeze)
        {
            state = MovementState.freeze;
            rb.velocity = Vector3.zero;
        }

        //Mode - Unlimited
        else if (unlimited)
        {
            state = MovementState.unlimited;
            moveSpeed = 999f;
            return;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}
