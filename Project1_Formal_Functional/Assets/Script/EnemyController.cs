using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform player;        // 玩家对象
    public Text killCountText;      // UI文本，显示击杀计数
    public float chaseRange = 10f;  // 敌人追击范围
    public float grabRange = 1.5f;  
    public float moveSpeed = 3.5f;  
    public int health = 3;          

    private NavMeshAgent agent;
    private bool isChasing = false;

    
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

        if (isChasing && distanceToPlayer <= grabRange)
        {
            GrabPlayer();
        }
    }

    // 敌人受到伤害
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
        killCount++;  // 增加击杀计数
        UpdateKillCountUI();  // 更新UI显示
        Destroy(gameObject);  // 销毁敌人
    }

    void GrabPlayer()
    {
        Debug.Log("Player has been caught!");
        agent.isStopped = true;

    }

    void UpdateKillCountUI()
    {
        if (killCountText != null)
        {
            killCountText.text = "Kills: " + killCount;  // 更新击杀计数显示
        }
    }
}
