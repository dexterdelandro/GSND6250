using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{

    public List<Collider> notes;
    public int numCounted;
    public bool shown = false;
    public int TotalNum = 4;

    public GameObject hiddenobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numCounted==4 && !shown){
            shown=true;
            hiddenobject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Key")){
            if(!notes.Contains(other)){
                numCounted++;
                notes.Add(other);
                Physics.IgnoreCollision(other, GetComponent<CapsuleCollider>(), true);
            }
            
        }
    }
}
