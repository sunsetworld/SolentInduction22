using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [Range(0f, 10f)] public float jumpHeight = 3f;
    [Range(0, 3)] public int maxAirJumps = 0;
    [Range(0, -20)] public float defaultGravity;
    [Range(0f, 5f)] public float downwardMovementMultiplier = 3f;
    [Range(0f, 5f)] public float upwardMovementMultiplier = 1.7f;

    private Rigidbody rb;
    private GroundCheck groundCheck;
    private Vector2 velocity;
    public ConstantForce gravity;

    private int jumpPhase;
    private float jumpSpeed;

    private bool desiredJump, isGrounded;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();
        gravity = gameObject.AddComponent<ConstantForce>();
    }


    void Update()
    {
        desiredJump |= Input.GetButtonDown("Jump");
    }


    private void FixedUpdate()
    {
        isGrounded = groundCheck.grounded;
        velocity = rb.velocity;

        if (isGrounded)
        {
            jumpPhase = 0;
        }

        if (desiredJump)
        {
            desiredJump = false;
            JumpAction();
        }

        if (rb.velocity.y > 0)
        {
            gravity.force = new Vector3(0.0f, defaultGravity * upwardMovementMultiplier, 0.0f);
        }
        else if (rb.velocity.y < 0)
        {
            gravity.force = new Vector3(0.0f, defaultGravity * downwardMovementMultiplier, 0.0f);
        }
        else if (rb.velocity.y == 0)
        {
            gravity.force = new Vector3(0.0f, defaultGravity, 0.0f);
        }

        rb.velocity = velocity;
    }


    private void JumpAction()
    {
        if (isGrounded || jumpPhase < maxAirJumps)
        {
            jumpPhase += 1;

            jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);

            if (velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            else if (velocity.y < 0f)
            {
                jumpSpeed += Mathf.Abs(rb.velocity.y);
            }
            velocity.y += jumpSpeed;
        }
    }
}
