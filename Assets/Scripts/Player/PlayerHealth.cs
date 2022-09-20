using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    private int maxHealth = 100;


    void Start()
    {
        health = maxHealth;
    }

    
    void Update()
    {
        
    }

    void OnHealthChange()
    {

    }
}

/* Max health - 25 Damage
 * No Health - 120 Damage
 * 
 * Loose 1 health per second (Stops at 10 health)
 * 