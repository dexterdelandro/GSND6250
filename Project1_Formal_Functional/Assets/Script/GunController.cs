using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;  // 子弹预制体
    public Transform firePoint;      // 发射子弹的位置
    public float bulletSpeed = 20f;  // 子弹速度

    void Update()
    {
        // 检测鼠标左键按下
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();  // 发射子弹
        }
    }

    void Shoot()
    {
        // 实例化子弹
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 获取子弹的刚体组件并让其向前运动
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;  // 子弹朝着枪口前方飞行
        }
    }
}
