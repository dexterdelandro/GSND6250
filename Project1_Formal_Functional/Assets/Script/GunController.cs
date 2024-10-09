using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;  // �ӵ�Ԥ����
    public Transform firePoint;      // �����ӵ���λ��
    public float bulletSpeed = 20f;  // �ӵ��ٶ�

    public Camera camera;

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

        Ray raycast = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        Vector3 hitVec;

        if(Physics.Raycast(raycast, out hit)){
            hitVec= hit.point;
        }else{
            hitVec = raycast.GetPoint(100);
        }


        // ʵ�����ӵ�
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // ��ȡ�ӵ��ĸ��������������ǰ�˶�
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = (hitVec - firePoint.position).normalized*bulletSpeed; // �ӵ�����ǹ��ǰ������
        }
    }
}
