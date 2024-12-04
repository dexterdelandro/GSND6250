using UnityEngine;
using UnityEngine.UI;

public class DocumentInteract : MonoBehaviour
{
    // UI���������ʾ�ĵ�
    public GameObject documentPanel;
    // ȷ������Ƿ��ڷ�Χ��
    private bool isPlayerInRange = false;
    // �Ƿ����ڲ鿴�ĵ�
    private bool isViewingDocument = false;
    

    void Start()
    {
        // ȷ���ĵ�����������ʱ�ǹرյ�
        documentPanel.SetActive(false);
    }

    void Update()
    {
        // ������ҽ��뷶Χ�Ұ���E��ʱ���ĵ�
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isViewingDocument)
        {
            OpenDocument();
        }

        // �������Ƿ���ESC�����ر��ĵ�
        if (isViewingDocument && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseDocument();
        }
    }

    // ����ҽ��봥����ʱ
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    // ������뿪������ʱ
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    // ���ĵ�����
    private void OpenDocument()
    {
        documentPanel.SetActive(true);
        isViewingDocument = true;
        // ��ͣ��Ϸ
        Time.timeScale = 0f;
    }

    // �ر��ĵ�����
    private void CloseDocument()
    {
        documentPanel.SetActive(false);
        isViewingDocument = false;
        // �ָ���Ϸ
        Time.timeScale = 1f;
    }
}
