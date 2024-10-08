using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CallElevator : MonoBehaviour
{
    public Elevate elevatorobj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals("Player"))
        {
            elevatorobj.call(transform.position);
        }
    }
}
