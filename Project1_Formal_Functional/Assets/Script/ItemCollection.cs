using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{

    public List<DocumentInteract> notes;
    public int numCounted;
    public bool shown = false;
    public int TotalNum = 4;

    public GameObject HiddenObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numCounted==4 && !shown){
            HiddenObject.SetActive(true);
            shown=true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Key"){
            numCounted++;
            Physics.IgnoreCollision(other, GetComponent<CapsuleCollider>(), true);
        }
    }
}
