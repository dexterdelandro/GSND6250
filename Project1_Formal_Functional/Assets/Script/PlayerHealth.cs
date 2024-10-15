using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;        // �������ֵ
    public int currentHealth;          // ��ǰ����ֵ
    public Text healthText;            // ������ʾ����״̬���ı�

    void Start()
    {
        currentHealth = maxHealth;     // ��ʼ����ǰ����ֵ
        UpdateHealthText();            // ���½�����ʾ
    }

    // ����ܵ��˺�ʱ����
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthText();             // ÿ�����˺���½�����ʾ

        if (currentHealth == 0)
        {
            Die();                      // ������ֵΪ0ʱ���������߼�
        }
    }

    // ��������߼�
    void Die()
    {
        Debug.Log("Player has died!");
        // ���������������Ϸ�����������߼�
    }

    // �����ı���ʾ��ҵĽ���״̬
    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth + "/" + maxHealth;
        }
    }
}
