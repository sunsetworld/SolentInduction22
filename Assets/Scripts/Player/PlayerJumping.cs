using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [Range(0f, 15f)] public float jumpHeight;
    [Range(0, 3)] public int maxAirJumps;
    [Range(0, -30)] public float defaultGravity;
    [Range(0f, 5f)] public float downwardMovementMultiplier = 2.5f;
    [Range(0f, 5f)] public float upwardMovementMultiplier = 1.7f;

    private Rigidbody rb;
    private GroundCheck groundCheck;
    private PlayerMovement playerMovement;
    private Vector2 velocity;
    public ConstantForce gravity;

    public bool variableJump;

    public float coyoteTime;
    private float coyoteCounter;

    private int jumpPhase;
    private float jumpSpeed;
    private float oldVelocity;

    private bool desiredJump, isGrounded, wasGrounded;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();
        gravity = gameObject.AddComponent<ConstantForce>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        desiredJump |= Input.GetButtonDown("Jump");

        if (Input.GetButtonUp("Jump") && variableJump && rb.velocity.y > 0)  // Variable jump
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.5f, 0);

        if (isGrounded)  // Coyote time manager
            coyoteCounter = coyoteTime;
        else
            coyoteCounter -= Time.deltaTime;
    }


    private void FixedUpdate()
    {
        isGrounded = groundCheck.grounded;
        velocity = rb.velocity;

        if (coyoteCounter > 0)  // Is grounded
        {
            jumpPhase = 0;  // Reset air jumps
        }

        if (desiredJump)
        {
            desiredJump = false;
            JumpAction();
        }

        if (rb.velocity.y > 0)  // Jumping up
        {
            gravity.force = new Vector3(0.0f, defaultGravity * upwardMovementMultiplier, 0.0f);
        }
        else if (rb.velocity.y < 0)  // Falling down
        {
            gravity.force = new Vector3(0.0f, defaultGravity * downwardMovementMultiplier, 0.0f);
        }
        else if (rb.velocity.y == 0)  // Grounded
        {
            gravity.force = new Vector3(0.0f, defaultGravity, 0.0f);
        }

        if (!wasGrounded && isGrounded)  // Landing
        {
            // <-- Particles
            // <-- Sound
            if (oldVelocity < 30)
            {
                Vector2 desiredVelocity = new Vector2(playerMovement.direction.x, 0f) * Mathf.Max(playerMovement.currentMoveSpeed * 10, 0f);
                velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, oldVelocity / 3);
            }
            else
            {
                // <-- Fall Damage
            }
        }

        wasGrounded = isGrounded;
        oldVelocity = -velocity.y + 2;

        rb.velocity = velocity;
    }


    private void JumpAction()
    {
        if (coyoteCounter > 0 || jumpPhase < maxAirJumps)
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

            // <-- Particles
            // <-- Sound
        }
    }
}
