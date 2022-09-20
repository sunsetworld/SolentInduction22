using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public int health;
    private int maxHealth = 100;


    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        health = maxHealth;
    }

    
    void Update()
    {
        OnHealthChange();
    }

    void OnHealthChange()
    {
        playerMovement.healthEffectStrength = -health + 100;
    }
}

/* Max health - 25 Damage
 * No Health - 120 Damage
 * 
 * Loose 1 health per second (Stops at 10 health)
 */