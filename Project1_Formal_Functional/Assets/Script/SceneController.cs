using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject enemyPrefab;  // 敌人预制体
    public Transform player;        // 玩家位置
    public float spawnRange = 20f;  // 敌人生成的最大范围
    public float minSpawnDistance = 10f; // 敌人生成的最小距离（离玩家）
    public int maxEnemies = 5;      // 最大敌人数量
    public Transform spawnArea;     // 检测玩家是否进入的触发区域
    private bool hasSpawnedEnemies = false; // 防止重复生成敌人
    private List<GameObject> enemies = new List<GameObject>(); // 当前场景中的敌人列表

    void OnTriggerEnter(Collider other)
    {
        // 检测玩家是否进入了触发区域
        if (other.CompareTag("Player") && !hasSpawnedEnemies)
        {
            hasSpawnedEnemies = true; // 确保只生成一次
            StartCoroutine(SpawnEnemies()); // 开始生成敌人
        }
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f); // 每隔1秒生成一个敌人
        }
    }

    void SpawnEnemy()
    {
        // 随机生成一个敌人的位置
        Vector3 spawnPosition;
        do
        {
            Vector2 randomPoint = Random.insideUnitCircle * spawnRange; // 在圆形区域内生成随机点
            spawnPosition = new Vector3(randomPoint.x, 0, randomPoint.y) + player.position;
        }
        while (Vector3.Distance(spawnPosition, player.position) < minSpawnDistance); // 确保敌人不在玩家太近的范围生成

        // 生成敌人并添加到敌人列表中
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemies.Add(newEnemy);
    }
}
