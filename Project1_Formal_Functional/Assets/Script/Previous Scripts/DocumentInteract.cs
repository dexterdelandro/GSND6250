using UnityEngine;
using UnityEngine.UI;

public class DocumentInteract : MonoBehaviour
{
    // UI面板用于显示文档
    public GameObject documentPanel;
    // 确定玩家是否在范围内
    private bool isPlayerInRange = false;
    // 是否正在查看文档
    private bool isViewingDocument = false;

    void Start()
    {
        // 确保文档界面在启动时是关闭的
        documentPanel.SetActive(false);
    }

    void Update()
    {
        // 仅在玩家进入范围且按下E键时打开文档
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isViewingDocument)
        {
            OpenDocument();
        }

        // 检查玩家是否按下ESC键来关闭文档
        if (isViewingDocument && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseDocument();
        }
    }

    // 当玩家进入触发器时
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    // 当玩家离开触发器时
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    // 打开文档界面
    private void OpenDocument()
    {
        documentPanel.SetActive(true);
        isViewingDocument = true;
        // 暂停游戏
        Time.timeScale = 0f;
    }

    // 关闭文档界面
    private void CloseDocument()
    {
        documentPanel.SetActive(false);
        isViewingDocument = false;
        // 恢复游戏
        Time.timeScale = 1f;
    }
}
