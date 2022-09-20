using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    private PlayerHealth playerHealth;
    private Rigidbody rb;

    [Header("Movement")]
    [Range(0, 10)] public float baseMoveSpeed;
    [Range(0, 50)] public float baseAcceleration;
    [Range(0, 50)] public float baseAirAcceleration;
    [Range(0, 100)] public float baseJumpHeight;
    //[Range(0, 100)] public int baseAttackDamage;

    public float healthEffectStrength;  // How much the ammount of health the player has will change the stats
    [Range(0, 150)] public float healthToSpeedIncrease;

    [SerializeField] private float currentMoveSpeed;
    [SerializeField] private float currentJumpHeight;
    //[SerializeField] private int currentAttackDamage;


    private Vector2 direction, desiredVelocity, velocity;
    private float maxSpeedChange, acceleration;
    private GroundCheck groundCheck;
    public bool isGrounded, isMoving;
    


    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();
    }


    
    void Update()
    {
        currentMoveSpeed = (baseMoveSpeed * (healthEffectStrength / healthToSpeedIncrease)) + baseMoveSpeed;
        //currentAttackDamage = baseAttackDamage + healthEffectStrength;

        direction.x = Input.GetAxisRaw("Horizontal");
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(currentMoveSpeed, 0f);
        if (rb.velocity.x != 0)
            isMoving = true;
        else
            isMoving = false;
    }



    private void FixedUpdate()
    {
        isGrounded = groundCheck.grounded;
        velocity = rb.velocity;

        acceleration = isGrounded ? baseAcceleration : baseAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        rb.velocity = velocity;
    }




    //Variable Jump Height - https://www.youtube.com/watch?v=Mo1-sKYbks0
    //Coyote Time - https://www.youtube.com/watch?v=RFix_Kg2Di0
    //Vertex Waves - https://www.youtube.com/watch?v=vje0x1BNpp8
}
