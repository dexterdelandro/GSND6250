using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerShoot : MonoBehaviour
{

    public Bullet bulletPrefab;

    public Transform firePoint;

    public float bulletSpeed;

    public float fireRate;
    public float lastFireTime;

    public bool fireContinuously; 
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(fireContinuously){
            if((Time.time - lastFireTime)>fireRate){
                Shoot();
                lastFireTime = Time.time;
            }
            
        }
    }

    void OnFire(InputValue inputValue){
        fireContinuously = inputValue.isPressed;
    }

    void Shoot(){
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = bulletSpeed * transform.up;
    }
}
