using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;      // 玩家最大生命值
    public int currentHealth;        // 当前生命值
    public Slider healthBar;         // 生命条UI滑块

    void Start()
    {
        currentHealth = maxHealth;   // 初始生命值为最大
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthBar();
    }

    void Die()
    {
        Debug.Log("Player has died!");
        // 玩家死亡处理逻辑
    }
     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            TakeDamage(5);
            Debug.Log("TakeDamage");
        }
    }


    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
        }
    }
}
