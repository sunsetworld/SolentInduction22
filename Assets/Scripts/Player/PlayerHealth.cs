using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator anim;
    public Material slimeMat;
    public Transform slimeEffect;

    [Range(0, 100)] public int health;
    private int maxHealth = 100;

    public int starvationAmmount;
    public int starvationSpeed;
    public int starvationStop;

    public float invincibilityTime;
    private float iFramesRemaining;



    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        health = maxHealth;
        StartCoroutine(StarvationDamage());
    }


    
    void Update()
    {
        OnHealthChange();

        if (iFramesRemaining > 0)
        {
            iFramesRemaining -= Time.deltaTime;
        }
    }



    void OnHealthChange()
    {
        playerMovement.healthEffectStrength = Mathf.RoundToInt((-health + 100) / 1.25f);
        slimeEffect.position = new Vector3(slimeEffect.position.x, transform.position.y + (0.035f + ((-health + 100f) / 5000)), slimeEffect.position.z);
        slimeMat.SetFloat("_Wave_Size", (health - 100f) / 45f);
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }



    private IEnumerator StarvationDamage()
    {
        yield return new WaitForSeconds(starvationSpeed);  // Wait a second

        if (health > starvationStop)  // If health is above 10
        {
            health -= starvationAmmount;  // Loose 1 health per second
        }

        StartCoroutine(StarvationDamage());  // Repeat
    }


    private void OnTriggerEnter(Collider col)
    {
        if (iFramesRemaining <= 0 && col.gameObject.CompareTag("Enemy Attack"))
        {
            iFramesRemaining = invincibilityTime;
            health -= 15;
            anim.SetTrigger("Hurt");
        }
    }
}