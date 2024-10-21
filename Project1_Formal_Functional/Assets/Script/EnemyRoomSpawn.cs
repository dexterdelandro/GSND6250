using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomSpawn : MonoBehaviour
{

    public List<Vector3>spawnLocations;

    public GameObject enemyPrefab;

    public float spawnRate;

    public float startDelay;

    public bool didSpawn = false;

    //public Transform player;



    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(StartDelay());


    }

    void Update(){
        if(!didSpawn) StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies(){
        didSpawn = true;
        yield return new WaitForSeconds(spawnRate);
        for(int i=0; i<spawnLocations.Count; i++){
            GameObject enemy = Instantiate(enemyPrefab, spawnLocations[i], Quaternion.identity);
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if(enemyController !=null){
                enemyController.player = FindObjectOfType<GunController>().gameObject.transform;
            }
        }

        didSpawn = false;
        
    }

    IEnumerator StartDelay(){
        yield return new WaitForSeconds(startDelay);
    }
}
