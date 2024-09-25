using UnityEngine;
using UnityEngine.UI; // ����UI���Դ�����Ļ��ʾ

public class TriggerMechanism : MonoBehaviour
{
    // ��ǰԿ�׶�Ӧ����
    public GameObject door;
    // ���յ��ţ����ռ�������Ʒ��򿪣�
    public GameObject finalDoor;
    // ��ʾ�ռ����ȵ�UI�ı�
    public Text progressText;

    // ��Ҫ�ռ�����������
    private static int totalObjects = 4; // ������Ҫ�ռ�4����Ʒ
    // ��ǰ���ռ���������
    private static int collectedObjects = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ��ӡ������Ϣ
            Debug.Log("����ռ���Կ�ף������ռ�����");

            // ��������������ʧ
            gameObject.SetActive(false);

            // �򿪵�ǰԿ�׶�Ӧ����
            door.SetActive(false);

            // �����ռ�����
            collectedObjects++;
            UpdateProgress();

            // ����Ƿ��ռ�������Կ��
            if (collectedObjects >= totalObjects)
            {
                Debug.Log("������Ʒ���ռ��������յ��ţ�");
                finalDoor.SetActive(false); // �����յ���
            }
        }
    }

    // ���½������ı��ķ���
    private void UpdateProgress()
    {
        // ������ʾ�ı����硰�ռ����ȣ�1/4��
        progressText.text = "Collection progress��" + collectedObjects + "/" + totalObjects;
        Debug.Log("��ǰ�ռ����ȣ�" + collectedObjects + "/" + totalObjects);
    }
}
