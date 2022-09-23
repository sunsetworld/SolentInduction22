using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    private Animator anim;
    public GameObject attackHitbox;
    public float hitboxLength;
    public int damage;
    public float attackCooldown;
    private bool cooldownComplete = true;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
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

    private IEnumerator Eat(GameObject target)
    {
        anim.Play("Slime - Eat");
        cooldownComplete = false;
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        yield return new WaitForSeconds(0.5f);
        Destroy(target);
        playerHealth.health += 25;
        StartCoroutine(Cooldown());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.GetComponent<enemyMain>().health <= 0 && cooldownComplete)
            {
                if (Input.GetAxisRaw("Vertical") < -0.5f)
                {
                    StartCoroutine(Eat(other.gameObject));
                }
            }
        }
    }
}
