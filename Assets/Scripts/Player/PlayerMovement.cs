using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerHealth playerHealth;

    public float baseMoveSpeed;
    public float baseJumpHeight;
    public int baseAttackDamage;

    public int healthEffectStrength;  // How much the ammount of health the player has will change the stats

    public float currentMoveSpeed;
    private float currentJumpHeight;
    public int currentAttackDamage;

    public bool isGrounded;
    


    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }


    
    void Update()
    {
        currentMoveSpeed = baseMoveSpeed * (healthEffectStrength / 10);
        currentAttackDamage = baseAttackDamage + healthEffectStrength;
    }

    //Variable Jump Height - https://www.youtube.com/watch?v=Mo1-sKYbks0
    //Coyote Time - https://www.youtube.com/watch?v=RFix_Kg2Di0
    //Movement - 
    // https://www.youtube.com/watch?v=8QPmhDYn6rk
}
