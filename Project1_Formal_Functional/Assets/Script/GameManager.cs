using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform player;      
    public Text killCountText;     
    public int maxEnemies = 5;     
    public float spawnRange = 20f; 

    public int round = 1;

    public bool haveSpawned = false;

    private int currentEnemyCount = 0; 

    void Start()
    {
        for(int i=0; i<maxEnemies; i++){
            SpawnEnemy();
        }
    }

    void Update(){

        Debug.Log(currentEnemyCount);

    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = player.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.player = player; 
            enemyController.killCountText = killCountText; 
        }

        currentEnemyCount++;
    }

    IEnumerator RoundWait(){
        float timeToWait = 25-(5*round);
        yield return new WaitForSeconds(timeToWait);
    }
}
