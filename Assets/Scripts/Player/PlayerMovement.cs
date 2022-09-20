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
    
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    
    void Update()
    {
        currentMoveSpeed = baseMoveSpeed * (healthEffectStrength / 10);
        currentAttackDamage = baseAttackDamage + healthEffectStrength;
    }
}
