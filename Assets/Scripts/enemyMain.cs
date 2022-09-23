using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyMain : MonoBehaviour
{
    public Transform player;
    protected NavMeshAgent EnemyNavMeshAgent;
    private PlayerMovement playerMovement;
    public float health;
    public float invincibilityTime;
    private float iFramesRemaining;

    // Start is called before the first frame update
    void Start()
    {
        EnemyNavMeshAgent = GetComponent<NavMeshAgent>();
        playerMovement = player.gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
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
        Debug.Log(col.gameObject);
        if (iFramesRemaining <= 0 && col.gameObject.CompareTag("Player Attack"))
        {
            iFramesRemaining = invincibilityTime;
            health -= playerMovement.currentAttackDamage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
