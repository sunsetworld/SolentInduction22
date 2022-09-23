using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator anim;
    public GameObject attackHitbox;
    public float hitboxLength;
    public int damage;
    public float attackCooldown;
    private bool cooldownComplete = true;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerMovement.controlsEnabled && cooldownComplete && Input.GetButtonDown("Fire1"))
            StartCoroutine(Hitbox());
                //direction.x = Input.GetButtonDown("Fire1");
    }

    private IEnumerator Hitbox()
    {
        //anim.SetTrigger("Attack");
        anim.Play("Slime - Attack");
        cooldownComplete = false;
        yield return new WaitForSeconds(0.1f);
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(hitboxLength);
        attackHitbox.SetActive(false);
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        attackHitbox.SetActive(false);
        cooldownComplete = true;
    }
}
