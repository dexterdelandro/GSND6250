using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera camera;

    public List<PlayerMovement> players;

    private void Awake() {
        camera = Camera.main;
    }
    // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(InputAction.CallbackContext context){
        //make sure action started
        if(!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(camera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        
        //ignore click if the object clicked on was not a player
        if(!rayHit.collider || !(rayHit.collider.gameObject.tag=="Player"))return;

        //set every character to inactive
        foreach(var x in players){
            x.isPlayer = false;
        }

        //then set clicked on player as active
        rayHit.collider.GetComponent<PlayerMovement>().isPlayer = true;
        
    }
}
