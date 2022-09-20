using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    private PlayerHealth playerHealth;
    private Rigidbody rb;

    [Header("Movement")]
    [Range(0, 100)] public float baseMoveSpeed;
    [Range(0, 100)] public float baseAcceleration;
    [Range(0, 100)] public float baseAirAcceleration;
    [Range(0, 100)] public float baseJumpHeight;
    //[Range(0, 100)] public int baseAttackDamage;

    public int healthEffectStrength;  // How much the ammount of health the player has will change the stats

    [SerializeField] private float currentMoveSpeed;
    [SerializeField] private float currentAcceleration;
    [SerializeField] private float currentAirAcceleration;
    [SerializeField] private float currentJumpHeight;
    //[SerializeField] private int currentAttackDamage;


    private Vector2 direction, desiredVelocity, velocity;
    private float maxSpeedChange, acceleration;
    //private GroundCheck groundCheck;
    public bool isGrounded;
    


    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody>();
        //groundCheck = GetComponent<GroundCheck>();
    }


    
    void Update()
    {
        currentMoveSpeed = baseMoveSpeed * (healthEffectStrength / 10);
        //currentAttackDamage = baseAttackDamage + healthEffectStrength;

        direction.x = Input.GetAxisRaw("Horizontal");
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(currentMoveSpeed - groundCheck.friction, 0f);
    }



    private void FixedUpdate()
    {
        isGrounded = groundCheck.onGround;
        velocity = rb.velocity;

        acceleration = isGrounded ? currentAcceleration : currentAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        rb.velocity = velocity;
    }




	//Variable Jump Height - https://www.youtube.com/watch?v=Mo1-sKYbks0
	//Coyote Time - https://www.youtube.com/watch?v=RFix_Kg2Di0
}
