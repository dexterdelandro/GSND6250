using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;        // 最大生命值
    public int currentHealth;          // 当前生命值
    public Text healthText;            // 用于显示健康状态的文本

    void Start()
    {
        currentHealth = maxHealth;     // 初始化当前生命值
        UpdateHealthText();            // 更新健康显示
    }

    // 玩家受到伤害时调用
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthText();             // 每次受伤后更新健康显示

        if (currentHealth == 0)
        {
            Die();                      // 当生命值为0时触发死亡逻辑
        }
    }

    // 玩家死亡逻辑
    void Die()
    {
        Debug.Log("Player has died!");
        // 可以在这里加入游戏结束或重生逻辑
    }

    // 更新文本显示玩家的健康状态
    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth + "/" + maxHealth;
        }
    }
}
