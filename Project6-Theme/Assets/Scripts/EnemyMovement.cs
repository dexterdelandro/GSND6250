using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;  // 巡逻时的速度
    public float chaseSpeed = 4f;  // 追逐玩家的速度
    public float patrolRange = 5f; // 巡逻的随机范围
    public float chaseRange = 3f;  // 追逐玩家的范围
    public float returnRange = 6f; // 返回巡逻状态的范围

    private Vector2 initialPosition;  // 敌人起始位置
    private Vector2 patrolTarget;     // 巡逻目标
    private Transform targetPlayer;   // 当前要追逐的玩家
    private Rigidbody2D rb;

    private bool isChasing = false;  // 是否在追逐
    private bool returningToPatrol = false;  // 是否返回巡逻状态

    // 手动添加多个玩家对象
    public List<GameObject> players;  // 玩家对象的列表

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        SetNewPatrolTarget(); // 设置初始巡逻目标
    }

    void Update()
    {
        if (isChasing && targetPlayer != null)
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

        DetectClosestPlayer();  // 检测最近的玩家
    }

    // 敌人的巡逻逻辑
    void Patrol()
    {
        Vector2 direction = (patrolTarget - (Vector2)transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        if (Vector2.Distance(transform.position, patrolTarget) < 0.1f)
        {
            SetNewPatrolTarget();
        }
    }

    // 设置新的巡逻目标
    void SetNewPatrolTarget()
    {
        float patrolOffsetX = Random.Range(-patrolRange, patrolRange);
        float patrolOffsetY = Random.Range(-patrolRange, patrolRange);
        patrolTarget = new Vector2(initialPosition.x + patrolOffsetX, initialPosition.y + patrolOffsetY);
    }

    // 追逐玩家
    void ChasePlayer()
    {
        Vector2 direction = (targetPlayer.position - transform.position).normalized;
        rb.velocity = direction * chaseSpeed;
    }

    // 返回巡逻
    void ReturnToPatrol()
    {
        Vector2 direction = (initialPosition - (Vector2)transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        if (Vector2.Distance(transform.position, initialPosition) < 0.1f)
        {
            returningToPatrol = false;
        }
    }

    // 检测最近的玩家
    void DetectClosestPlayer()
    {
        float closestDistance = Mathf.Infinity; // 用于找到最近的玩家
        Transform closestPlayer = null;

        // 遍历所有玩家，找到最近的玩家
        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer < closestDistance && distanceToPlayer < chaseRange)
            {
                closestDistance = distanceToPlayer;
                closestPlayer = player.transform;
            }
        }

        // 如果找到了最近的玩家，开始追逐
        if (closestPlayer != null)
        {
            targetPlayer = closestPlayer;
            isChasing = true;
            returningToPatrol = false;
        }
        else if (targetPlayer == null || Vector2.Distance(transform.position, targetPlayer.position) > returnRange)
        {
            isChasing = false;
            returningToPatrol = true;
        }
    }

    // 碰撞检测，当敌人碰到玩家时
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 此处可以添加玩家受到伤害的逻辑
            Debug.Log("Enemy caught the player!");
        }
    }
}
