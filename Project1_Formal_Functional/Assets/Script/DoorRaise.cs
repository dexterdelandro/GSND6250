using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRaise : MonoBehaviour
{

    public float raiseDistance;

    private Vector3 targetLocation;
    public float speed;

    public GameObject door;

    public bool didActivate = false;
    // Start is called before the first frame update
    void Start()
    {
        targetLocation = new Vector3(transform.position.x, transform.position.y + raiseDistance, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(didActivate)
        door.transform.position = Vector3.MoveTowards(door.transform.position, targetLocation, speed*Time.deltaTime);
    }

    // void OnCollisionEnter(Collision other) {
    //     if(other.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("touching player");
    //         if(other.gameObject.GetComponent<ItemCollection>().keyCollected) didActivate = true;
    //     }
    // }

    // void OnTriggerEnter(Collider other){
    //      if(other.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("touching player");
    //         if(other.gameObject.GetComponent<ItemCollection>().keyCollected) didActivate = true;
    //     }
    // }
}
