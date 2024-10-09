using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;  // �ӵ�Ԥ����
    public Transform firePoint;      // �����ӵ���λ��
    public float bulletSpeed = 20f;  // �ӵ��ٶ�

    void Update()
    {
        // �������������
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();  // �����ӵ�
        }
    }

    void Shoot()
    {
        // ʵ�����ӵ�
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // ��ȡ�ӵ��ĸ��������������ǰ�˶�
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;  // �ӵ�����ǹ��ǰ������
        }
    }
}
