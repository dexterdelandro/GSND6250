using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; 

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;

    public bool isPlayer;

    public int maxHealth = 100; 
    public int currentHealth; 
    public GameObject healthBarPrefab; 
    private GameObject healthBar; 
    public Transform healthBarPosition; 

    void Start()
    {
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
    
}
