using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossFight : MonoBehaviour
{

    public GameObject bossP1;
    public GameObject bossP2;
    public GameObject bossP3;
    public GameObject[] itemsToCollectR1;
    public GameObject[] itemsToCollectR2;
    public GameObject[] itemsToCollectR3;
    public GameObject door;
    public GameObject door2;

    public GameObject secret;

    public GameObject enemiesP1;

    public GameObject enemiesP2;
    public int ItemCountR1 = 4;
    public int ItemCountR2 = 3;
    public int ItemCountR3 = 4;
    private int CollectedItem = 0;
    // Start is called before the first frame update
    async void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < itemsToCollectR1.Length; i++)
        {
            if (other.gameObject == itemsToCollectR1[i])
            {

                other.gameObject.SetActive(false);
                CollectedItem++;
                
                if (CollectedItem >= ItemCountR1)
                {
                    Debug.Log("DONE COLLECTING");
                    CollectedItem = 0;
                    bossP1.GetComponentInChildren<ParticleSystem>().Play();
                    StartCoroutine(DamagePhaseTimer(1));
                }
            }
        }

        for (int i = 0; i < itemsToCollectR2.Length; i++)
        {
            if (other.gameObject == itemsToCollectR2[i])
            {

                other.gameObject.SetActive(false);
                CollectedItem++;

                if (CollectedItem >= ItemCountR2)
                {
                    bossP2.GetComponentInChildren<ParticleSystem>().Play();
                    CollectedItem = 0;
                    StartCoroutine(DamagePhaseTimer(2));
                }
            }
        }
        for (int i = 0; i < itemsToCollectR3.Length; i++)
        {
            if (other.gameObject == itemsToCollectR3[i])
            {

                other.gameObject.SetActive(false);
                CollectedItem++;

                if (CollectedItem >= ItemCountR3)
                {
                    
                    bossP3.GetComponentInChildren<ParticleSystem>().Play();
                    StartCoroutine(DamagePhaseTimer(3));
                }
            }
        }

    }

    IEnumerator DamagePhaseTimer(int x){

        switch(x){
            case 1:
                bossP1.GetComponentInChildren<ParticleSystem>().Play();
                yield return new WaitForSeconds(6);
                bossP1.SetActive(false);
                door.SetActive(false);
                bossP2.SetActive(true);
                enemiesP1.SetActive(true);
                break;
            case 2:
                bossP2.GetComponentInChildren<ParticleSystem>().Play();
                yield return new WaitForSeconds(6);
                bossP2.SetActive(false);
                door2.SetActive(false);
                bossP3.SetActive(true);
                secret.SetActive(true);
                enemiesP1.SetActive(false);
                enemiesP2.SetActive(true);
                break;
            case 3:
                bossP3.GetComponentInChildren<ParticleSystem>().Play();
                yield return new WaitForSeconds(30);
                
                bossP3.SetActive(false);
                break;
            
        }
    }

   
}
