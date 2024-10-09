using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // ����Ԥ����
    public Transform player;        // ��Ҷ���
    public Text killCountText;      // UI�ı���������ʾ��ɱ����
    public int maxEnemies = 5;      // ��������
    public float spawnRange = 20f;  // �������ɷ�Χ

    private int currentEnemyCount = 0; // ��ǰ������

    void Start()
    {
        // ȷ����ʼʱ���㹻�ĵ�������
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // ���ɵ���λ�õ������
        Vector3 spawnPosition = player.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

        // ʵ��������Ԥ����
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // ��ȡ���˵� EnemyController �ű������� player �� UI Text
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.player = player; // ��̬������Ҷ���
            enemyController.killCountText = killCountText; // ��̬����UI�ı�
        }

        currentEnemyCount++;
    }
}
