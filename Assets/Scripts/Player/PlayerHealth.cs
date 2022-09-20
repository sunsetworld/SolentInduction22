using System.Collections;
using System.Collections.Generic;
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
        //if (health)
    }
}
