using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; 

public class PlayerMovement : MonoBehaviour
{

    public GameObject gun;
    public bool facingRight;
    public Bullet bulletPrefab;

    public Transform firePoint;

    public float bulletSpeed;

    public float fireRate;
    public float lastFireTime;

    public bool fireContinuously; 
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;

    public bool isPlayer;

    public int maxHealth = 100; 
    public int currentHealth; 
    public GameObject healthBarPrefab; 
    private GameObject healthBar; 
    public Transform healthBarPosition; 

    public SpriteRenderer spriteRenderer;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; 

        
        healthBar = Instantiate(healthBarPrefab, healthBarPosition.position, Quaternion.identity, transform);

        
        healthBar.transform.localScale = Vector3.one;

        
        if (healthBar.GetComponentInChildren<Image>() == null)
        {
            Debug.LogError("Health Bar prefab is missing an Image component!");
        }

        UpdateHealthBar();
    }


    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }

        //everything below is only what the active player does
        if(!isPlayer)return;

         Vector2 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
         gun.transform.up = (Vector3)(mousePosition - new Vector2(transform.position.x, transform.position.y));
        // Debug.Log(transform.up);
        // if(transform.up.x<0){
        //     if(facingRight==true){
        //         facingRight=false;
        //         spriteRenderer.flipX = true;
        //         spriteRenderer.flipY = true;
        //     }
        // }else{
        //     if(facingRight==false){
        //         facingRight = true;
        //         spriteRenderer.flipX = false;
        //         spriteRenderer.flipY = false;
        //     }
        // }

        if(fireContinuously){
            if((Time.time - lastFireTime)>fireRate){
                Shoot();
                lastFireTime = Time.time;
            }
            
        }
       

    }

    void FixedUpdate()
    {
        if (!isPlayer) movement = Vector2.zero;
        rb.velocity = movement.normalized * moveSpeed;
    }

    void OnMove(InputValue inputValue)
    {
        if (isPlayer) movement = inputValue.Get<Vector2>();
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10); 
        }
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
    }

    
    void UpdateHealthBar()
    {
        
        if (healthBar != null)
        {
            
            Image healthBarImage = healthBar.GetComponentInChildren<Image>();
            if (healthBarImage != null)
            {
                
                healthBarImage.fillAmount = (float)currentHealth / maxHealth;
            }
            else
            {
                Debug.LogError("Health Bar Image component not found!");
            }
        }
        else
        {
            Debug.LogError("Health Bar is null!");
        }
    }



    
    void Die()
    {
        
        Debug.Log("Player has died.");
        gameObject.SetActive(false); 
    }

    void OnFire(InputValue inputValue){
        fireContinuously = inputValue.isPressed;
    }

    void Shoot(){
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, gun.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = bulletSpeed * gun.transform.up;
    }
    
}
