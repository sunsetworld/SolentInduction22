using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyMain : MonoBehaviour
{
    public Transform player;
    protected NavMeshAgent EnemyNavMeshAgent;
    private PlayerMovement playerMovement;
    public Animator anim; 

    public float health;
    public float invincibilityTime;
    private float iFramesRemaining;
    private Vector3 prevPos, actualPos;

    public GameObject attackHitbox;
    public float hitboxLength;
    public int damage;
    public float attackCooldown;
    private bool cooldownComplete = true;


    void Start()
    {
        EnemyNavMeshAgent = GetComponent<NavMeshAgent>();
        playerMovement = player.gameObject.GetComponent<PlayerMovement>();
        StartCoroutine(MovingCheck());
    }


    void Update()
    {
        EnemyNavMeshAgent.SetDestination(player.position);

        if (iFramesRemaining > 0)
        {
            iFramesRemaining -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        if (iFramesRemaining <= 0 && col.gameObject.CompareTag("Player Attack"))
        {
            iFramesRemaining = invincibilityTime;
            health -= playerMovement.currentAttackDamage;
            anim.SetTrigger("Hurt");
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator MovingCheck()
    {
        prevPos = transform.position;
        yield return new WaitForSeconds(0.3f);
        actualPos = transform.position;

        if (Vector3.Distance(prevPos, actualPos) <= 0.8f) 
            anim.SetBool("Moving", false);
        else
            anim.SetBool("Moving", true);

        if (Vector3.Distance(player.position, actualPos) <= 5f && cooldownComplete)
            StartCoroutine(Hitbox());

        StartCoroutine(MovingCheck());
    }


    private IEnumerator Hitbox()
    {
        cooldownComplete = false;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
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
