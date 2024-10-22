using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb; 
    private Vector2 movement; 

    public bool isPlayer;

    // Update is called once per frame

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        if(!isPlayer) movement = Vector2.zero;
        rb.velocity = movement.normalized * moveSpeed;

    }

    void OnMove(InputValue inputValue){
        
        if(isPlayer)movement = inputValue.Get<Vector2>();
    }
}
