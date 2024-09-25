using UnityEngine;
using UnityEngine.UI; 

public class TriggerMechanism : MonoBehaviour
{
    
    public GameObject door;
    
    public GameObject finalDoor;
   
    public Text progressText;

    
    private static int totalObjects = 4; 
  
    private static int collectedObjects = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            
            
            gameObject.SetActive(false);

          
            door.SetActive(false);

          
            collectedObjects++;
            UpdateProgress();

     
            if (collectedObjects >= totalObjects)
            {
            
                finalDoor.SetActive(false); 
            }
        }
    }

    private void UpdateProgress()
    {
        
        progressText.text = "Collection progress:m" + collectedObjects + "/" + totalObjects;
        
    }
}
