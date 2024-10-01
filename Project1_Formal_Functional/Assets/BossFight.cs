using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossFight : MonoBehaviour
{
    public GameObject[] itemsToCollectR1;
    public GameObject[] itemsToCollectR2;
    public GameObject[] itemsToCollectR3;
    public GameObject door;
    public GameObject door2;
    public GameObject Boss;
    public int ItemCountR1 = 4;
    public int ItemCountR2 = 3;
    public int ItemCountR3 = 4;
    private int CollectedItem = 0;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < itemsToCollectR1.Length; i++)
        {
            if (other.gameObject == itemsToCollectR1[i])
            {

                other.gameObject.SetActive(false);
                CollectedItem++;
                
                if (CollectedItem >= ItemCountR1)
                {
                    door.SetActive(false);
                    Boss.transform.position = new Vector3(22, 4, -5);
                    CollectedItem = 0;
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
                    door2.SetActive(false);
                    Boss.transform.position = new Vector3(2, 8, 42);
                    CollectedItem = 0;
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
                    
                    Boss.SetActive(false);
                }
            }
        }

    }

   
}
