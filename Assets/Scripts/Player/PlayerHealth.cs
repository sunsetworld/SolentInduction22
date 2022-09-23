using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [Range(0, 100)] public int health;
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
        OnHealthChange();
    }



    void OnHealthChange()
    {
        playerMovement.healthEffectStrength = Mathf.RoundToInt((-health + 100) / 1.25f);
    }



    private IEnumerator StarvationDamage()
    {
        yield return new WaitForSeconds(starvationSpeed);  // Wait a second

        if (health > starvationStop)  // If health is above 10
        {
            health -= starvationAmmount;  // Loose 1 health per second
            OnHealthChange();
        }

        StartCoroutine(StarvationDamage());  // Repeat
    }

    public int GetHealth()
    {
        return health;
    }

    public void AddHealth(int healthToAdd)
    {
        health += healthToAdd;
    }
}