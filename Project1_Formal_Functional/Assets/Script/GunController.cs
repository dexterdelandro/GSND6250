using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public GameObject[] guns;          // 三把枪
    public GameObject bulletPrefab;    // 子弹预制体
    public Transform firePoint;        // 枪口位置
    public float bulletSpeed = 20f;    // 子弹速度
    public float fireRate = 0.5f;      // 默认的射速（每秒发射的子弹数）
    public Camera camera;              // 摄像机
    private int currentGunIndex = 0;   // 当前枪的索引
    private float nextFireTime = 0f;   // 下次可以射击的时间

    public int gunLevel = 0;

    public Slider xpSlider;

    void Start()
    {
        EquipGun(currentGunIndex);  // 游戏开始时装备第一把枪
    }

    void Update()
    {
        // 检测射击输入
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // 计算下一次射击时间
        }

        // 检测按键输入 (例如 "E" 键) 切换武器
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchGun();  // 切换武器
        }
    }

    // 射击方法
    void Shoot()
    {
        Ray raycast = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 hitVec;

        if (Physics.Raycast(raycast, out hit))
        {
            hitVec = hit.point;
        }
        else
        {
            hitVec = raycast.GetPoint(100);
        }

        // 使用子弹预制体生成子弹
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (hitVec - firePoint.position).normalized;
            rb.velocity = direction * bulletSpeed;
        }
    }

    // 切换到下一把枪，并增加射速和威力
    public void SwitchGun()
    {
        currentGunIndex = (currentGunIndex + 1) % guns.Length; // 切换到下一把枪
        if(currentGunIndex>gunLevel)currentGunIndex = gunLevel;
        fireRate += 0.5f;   // 每次切换增加射速
        bulletSpeed += 5f;  // 每次切换增加子弹速度（威力）
        EquipGun(currentGunIndex); // 切换时更新装备的枪
        Debug.Log("切换到枪械: " + currentGunIndex + "，射速: " + fireRate + "，威力: " + bulletSpeed);
    }

    // 装备枪械的方法
    private void EquipGun(int gunIndex)
    {
        // 禁用所有枪械
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }

        // 只激活当前枪械
        guns[gunIndex].SetActive(true);

        Debug.Log("装备了枪械: " + gunIndex);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "MagicWell"){
            if(xpSlider.value>=1){
                Debug.Log("upgrading gun");
                xpSlider.value = 0;
                gunLevel++;
                EquipGun(gunLevel);
            }else{
                Debug.Log("NOT ENOUGH XP");
            }
        }
    }
}
