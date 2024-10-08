using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevate : MonoBehaviour
{
    public float maxHeight = 3;
    public float minHeight = 0;
    public float speed = 1;
    bool isuping = false;
    bool iswaiting = true;
    float waitingTime = 0;
    float waitedTime = 0;
    Vector3 callPosition;
    // Start is called before the first frame update
    void Start()
    {
       iswaiting = true;
       waitingTime = 10;
       callPosition = transform.position;
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
        if(callPosition.x != transform.position.x || callPosition.z != transform.position.z)
        {
            bool isRight = callPosition.x - transform.position.x > 0;
            bool isForward = callPosition.z - transform.position.z > 0;
            if(transform.position.y==minHeight)
            {
                if(transform.position.x != transform.position.x || callPosition.z != transform.position.z)
                {
                    transform.Translate((isRight? 1: -1)*transform.right * Time.deltaTime*speed);
                }
                else
                {
                    transform.Translate((isForward? 1: -1)*transform.forward * Time.deltaTime*speed);
                }
            }
            Vector3 pos = transform.position;
            if(isRight? transform.position.x>callPosition.x: transform.position.x<callPosition.x)
            {
                pos.x = callPosition.x;
            }
            if(isForward? transform.position.z>callPosition.z: transform.position.z<callPosition.z)
            {
                pos.z = callPosition.z;
            }
            transform.position = pos;
            return;
        }
        transform.Translate((isuping? Vector3.up: Vector3.down) * Time.deltaTime*speed);
        if(transform.position.y >= maxHeight)
        {
            isuping = false;
        }
        if(transform.position.y <= 0)
        {
            iswaiting = true;
                waitedTime = 10;
            isuping = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        iswaiting = true;
    }
    public void call(Vector3 position)
    {
        callPosition = position;
    }
}
