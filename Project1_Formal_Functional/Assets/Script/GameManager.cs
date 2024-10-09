using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // 敌人预制体
    public Transform player;        // 玩家对象
    public Text killCountText;      // UI文本，用于显示击杀计数
    public int maxEnemies = 5;      // 最大敌人数
    public float spawnRange = 20f;  // 敌人生成范围

    private int currentEnemyCount = 0; // 当前敌人数

    void Start()
    {
        // 确保开始时有足够的敌人生成
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // 生成敌人位置的随机点
        Vector3 spawnPosition = player.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

        // 实例化敌人预制体
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // 获取敌人的 EnemyController 脚本并设置 player 和 UI Text
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.player = player; // 动态分配玩家对象
            enemyController.killCountText = killCountText; // 动态分配UI文本
        }

        currentEnemyCount++;
    }
}
