using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float chaseSpeed = 4f; 
    public float patrolRange = 5f; 
    public float chaseRange = 3f; 
    public float returnRange = 6f; 

    private Vector2 initialPosition; 
    private Vector2 patrolTarget; 
    private Transform player; 
    private Rigidbody2D rb;

    private bool isChasing = false; 
    private bool returningToPatrol = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        SetNewPatrolTarget(); 
    }

    void Update()
    {
        if (isChasing && player != null)
        {
            ChasePlayer();
        }
        else if (returningToPatrol)
        {
            ReturnToPatrol();
        }
        else
        {
            Patrol();
        }

        
        DetectPlayer();
    }

   
    void Patrol()
    {
       
        Vector2 direction = (patrolTarget - (Vector2)transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        
        if (Vector2.Distance(transform.position, patrolTarget) < 0.1f)
        {
            SetNewPatrolTarget();
        }
    }

    
    void SetNewPatrolTarget()
    {
        float patrolOffsetX = Random.Range(-patrolRange, patrolRange);
        float patrolOffsetY = Random.Range(-patrolRange, patrolRange);
        patrolTarget = new Vector2(initialPosition.x + patrolOffsetX, initialPosition.y + patrolOffsetY);
    }

    
    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * chaseSpeed;
    }

   
    void ReturnToPatrol()
    {
        Vector2 direction = (initialPosition - (Vector2)transform.position).normalized;
        rb.velocity = direction * moveSpeed;

       
        if (Vector2.Distance(transform.position, initialPosition) < 0.1f)
        {
            returningToPatrol = false;
        }
    }

    
    void DetectPlayer()
    {
        
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }

        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer < chaseRange)
            {
                isChasing = true;
                returningToPatrol = false;
            }
            else if (distanceToPlayer > returnRange)
            {
                isChasing = false;
                returningToPatrol = true;
            }
        }
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Enemy caught the player!");
        }
    }
}
