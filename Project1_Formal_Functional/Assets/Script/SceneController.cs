using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject enemyPrefab;  // ����Ԥ����
    public Transform player;        // ���λ��
    public float spawnRange = 20f;  // �������ɵ����Χ
    public float minSpawnDistance = 10f; // �������ɵ���С���루����ң�
    public int maxEnemies = 5;      // ����������
    public Transform spawnArea;     // �������Ƿ����Ĵ�������
    private bool hasSpawnedEnemies = false; // ��ֹ�ظ����ɵ���
    private List<GameObject> enemies = new List<GameObject>(); // ��ǰ�����еĵ����б�

    void OnTriggerEnter(Collider other)
    {
        // �������Ƿ�����˴�������
        if (other.CompareTag("Player") && !hasSpawnedEnemies)
        {
            hasSpawnedEnemies = true; // ȷ��ֻ����һ��
            StartCoroutine(SpawnEnemies()); // ��ʼ���ɵ���
        }
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f); // ÿ��1������һ������
        }
    }

    void SpawnEnemy()
    {
        // �������һ�����˵�λ��
        Vector3 spawnPosition;
        do
        {
            Vector2 randomPoint = Random.insideUnitCircle * spawnRange; // ��Բ�����������������
            spawnPosition = new Vector3(randomPoint.x, 0, randomPoint.y) + player.position;
        }
        while (Vector3.Distance(spawnPosition, player.position) < minSpawnDistance); // ȷ�����˲������̫���ķ�Χ����

        // ���ɵ��˲���ӵ������б���
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemies.Add(newEnemy);
    }
}
