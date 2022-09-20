using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerHealth playerHealth;

    public float baseMoveSpeed;
    public float baseJumpHeight;
    public float healthEffectStrength;  // How much the ammount of health the player has will change the stats

    public float currentMoveSpeed;
    private float currentJumpHeight;
    
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    
    void Update()
    {
        // If left key pressed
        currentMoveSpeed = baseMoveSpeed * ((playerHealth.health) / healthEffectStrength);
    }
}
