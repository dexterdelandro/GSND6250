using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevate : MonoBehaviour
{
    public float maxHeight = 3;
    public float minHeight = 0;
    public float speed = 1;
    bool isuping = false;
    bool iswaiting = false;
    float waitingTime = 10;
    float waitedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
       iswaiting = true;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if(iswaiting)
        {
            waitedTime += Time.deltaTime;
            if(waitedTime >= waitingTime)
            {
                iswaiting = false;
                waitedTime = 0;
            }
        }
    }
    void move()
    {
        if(iswaiting) return;
       
        transform.Translate((isuping? Vector3.up: Vector3.down) * Time.deltaTime*speed);
        if(transform.position.y >= maxHeight)
        {
            isuping = false;
            iswaiting = true;
            waitingTime = 5;
        }
        if(transform.position.y <= 0)
        {
            isuping = true;
            iswaiting = true;
            waitingTime = 5;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        iswaiting = true;
    }
}
