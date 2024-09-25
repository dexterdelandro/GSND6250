using UnityEngine;
using UnityEngine.UI; // 引入UI库以处理屏幕显示

public class TriggerMechanism : MonoBehaviour
{
    // 当前钥匙对应的门
    public GameObject door;
    // 最终的门（在收集所有物品后打开）
    public GameObject finalDoor;
    // 显示收集进度的UI文本
    public Text progressText;

    // 需要收集的总物体数
    private static int totalObjects = 4; // 假设需要收集4个物品
    // 当前已收集的物体数
    private static int collectedObjects = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 打印调试信息
            Debug.Log("玩家收集到钥匙，更新收集进度");

            // 触碰到的物体消失
            gameObject.SetActive(false);

            // 打开当前钥匙对应的门
            door.SetActive(false);

            // 更新收集进度
            collectedObjects++;
            UpdateProgress();

            // 检查是否收集了所有钥匙
            if (collectedObjects >= totalObjects)
            {
                Debug.Log("所有物品已收集，打开最终的门！");
                finalDoor.SetActive(false); // 打开最终的门
            }
        }
    }

    // 更新进度条文本的方法
    private void UpdateProgress()
    {
        // 更新显示文本，如“收集进度：1/4”
        progressText.text = "Collection progress：" + collectedObjects + "/" + totalObjects;
        Debug.Log("当前收集进度：" + collectedObjects + "/" + totalObjects);
    }
}
