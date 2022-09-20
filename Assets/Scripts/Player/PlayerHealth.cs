using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public int health;
    private int maxHealth = 100;

    public int starvationAmmount;
    public int starvationSpeed;
    public int starvationStop;


    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        health = maxHealth;
        StartCoroutine(StarvationDamage());
    }

    
    void Update()
    {

    }

    void OnHealthChange()
    {
        playerMovement.healthEffectStrength = -health + 100;
    }

    private IEnumerator StarvationDamage()
    {
        yield return new WaitForSeconds(starvationSpeed);

        if (health >= starvationStop)
        {
            health -= starvationAmmount;
            OnHealthChange();
        }

        StartCoroutine(StarvationDamage());
    }
}


/* Max health - 25 Damage
 * No Health - 120 Damage
 * 
 * Loose 1 health per second (Stops at 10 health)
 */