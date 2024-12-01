using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform player;      
    public Text killCountText;     
    public int maxEnemies = 5;     
    public float spawnRange = 20f; 

    public List<Light> lights;

    public int round = 1;

    public bool rest = false;

    public bool didStart = false;

    private int currentEnemyCount = 5; 

    void Start()
    {
        
    }

    void Update(){

        if(!didStart){
            if(player.position.x>-18 && player.position.x<18 &&
               player.position.z>-18 && player.position.z<18){
                didStart = true;

                for(int i=0; i<maxEnemies; i++){
                    SpawnEnemy();
                }
            }
        }

        currentEnemyCount = FindObjectsOfType<EnemyController>().Length;
        
        if(didStart && currentEnemyCount ==0 && !rest){
            NextRound();
        }

    }

    private void NextRound(){
        rest = true;
        round++;
        StartCoroutine(RoundWait());
    }

    
    IEnumerator RoundWait(){
        float timeToWait = 20-(5*round);
        Debug.Log("WAITING");
        for(int i=0; i<lights.Count; i++){
            lights[i].color = Color.green;
        }
        yield return new WaitForSeconds(timeToWait);
        for(int i=0; i<lights.Count; i++){
            lights[i].color = Color.yellow;
        }
        yield return new WaitForSeconds(5);
        for(int i=0; i<lights.Count; i++){
            lights[i].color = Color.white;
        }
        maxEnemies += 3;
        for(int i=0; i<maxEnemies; i++){
            SpawnEnemy();
        }
        Debug.Log("Starting Round " + round);
        rest = false;
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition =new Vector3(Random.Range(-18, 18), 151.24f, Random.Range(-18f, 18));

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.player = player; 
            enemyController.killCountText = killCountText; 
        }

        currentEnemyCount++;
    }

}
