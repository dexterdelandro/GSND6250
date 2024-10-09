using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;      // ����������ֵ
    public int currentHealth;        // ��ǰ����ֵ
    public Slider healthBar;         // ������UI����

    void Start()
    {
        currentHealth = maxHealth;   // ��ʼ����ֵΪ���
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
        // ������������߼�
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
