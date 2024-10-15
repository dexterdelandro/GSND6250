using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform player;          
    public Text killCountText;        
    public float chaseRange = 10f;    
    public float grabRange = 1.5f;    
    public float moveSpeed = 3.5f;    
    public int health = 3;            
    public int damage = 10;           
    public float attackCooldown = 1f; 

    private NavMeshAgent agent;
    private bool isChasing = false;
    private float lastAttackTime;     

    public static int killCount = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;

        UpdateKillCountUI();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        
        if (distanceToPlayer <= chaseRange)
        {
            isChasing = true;
            agent.SetDestination(player.position); 
        }
        else
        {
            isChasing = false;
        }

        
        if (isChasing && distanceToPlayer <= grabRange && Time.time >= lastAttackTime + attackCooldown)
        {
            GrabPlayer();  
        }
    }

    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        killCount++;  
        UpdateKillCountUI();  
        Destroy(gameObject);  
    }

    void GrabPlayer()
    {
        Debug.Log("Enemy attacks the player!");

       
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

       
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);  
        }

        
        lastAttackTime = Time.time;
    }

    void UpdateKillCountUI()
    {
        if (killCountText != null)
        {
            killCountText.text = "Kills: " + killCount;  
        }
    }
}
