using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;  // Ѳ��ʱ���ٶ�
    public float chaseSpeed = 4f;  // ׷����ҵ��ٶ�
    public float patrolRange = 5f; // Ѳ�ߵ������Χ
    public float chaseRange = 3f;  // ׷����ҵķ�Χ
    public float returnRange = 6f; // ����Ѳ��״̬�ķ�Χ

    private Vector2 initialPosition;  // ������ʼλ��
    private Vector2 patrolTarget;     // Ѳ��Ŀ��
    private Transform targetPlayer;   // ��ǰҪ׷������
    private Rigidbody2D rb;

    private bool isChasing = false;  // �Ƿ���׷��
    private bool returningToPatrol = false;  // �Ƿ񷵻�Ѳ��״̬

    // �ֶ���Ӷ����Ҷ���
    public List<GameObject> players;  // ��Ҷ�����б�

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        SetNewPatrolTarget(); // ���ó�ʼѲ��Ŀ��
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

        DetectClosestPlayer();  // �����������
    }

    // ���˵�Ѳ���߼�
    void Patrol()
    {
        Vector2 direction = (patrolTarget - (Vector2)transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        if (Vector2.Distance(transform.position, patrolTarget) < 0.1f)
        {
            SetNewPatrolTarget();
        }
    }

    // �����µ�Ѳ��Ŀ��
    void SetNewPatrolTarget()
    {
        float patrolOffsetX = Random.Range(-patrolRange, patrolRange);
        float patrolOffsetY = Random.Range(-patrolRange, patrolRange);
        patrolTarget = new Vector2(initialPosition.x + patrolOffsetX, initialPosition.y + patrolOffsetY);
    }

    // ׷�����
    void ChasePlayer()
    {
        Vector2 direction = (targetPlayer.position - transform.position).normalized;
        rb.velocity = direction * chaseSpeed;
    }

    // ����Ѳ��
    void ReturnToPatrol()
    {
        Vector2 direction = (initialPosition - (Vector2)transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        if (Vector2.Distance(transform.position, initialPosition) < 0.1f)
        {
            returningToPatrol = false;
        }
    }

    // �����������
    void DetectClosestPlayer()
    {
        float closestDistance = Mathf.Infinity; // �����ҵ���������
        Transform closestPlayer = null;

        // ����������ң��ҵ���������
        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer < closestDistance && distanceToPlayer < chaseRange)
            {
                closestDistance = distanceToPlayer;
                closestPlayer = player.transform;
            }
        }

        // ����ҵ����������ң���ʼ׷��
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

    // ��ײ��⣬�������������ʱ
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �˴������������ܵ��˺����߼�
            Debug.Log("Enemy caught the player!");
        }
    }
}
