using UnityEngine;
using System.Collections;

public class Shoot_Enemy : MonoBehaviour
{
    IEnumerator shootingCoroutine;
    Rigidbody2D enemyRigidbody;
    Shoots[] guns;
    public static Shoot_Enemy instance;

    [Header("Shooting Settings")]
    public bool facingRight = true; // Chọn hướng

    void Awake()
    {

    }

    void Start()
    {
        InitializeComponents();
        StartShootingRoutine();
    }

    private void InitializeComponents()
    {
        // Khởi tạo thành phần cần thiếtthiết
        enemyRigidbody = GetComponent<Rigidbody2D>();
        guns = GetComponentsInChildren<Shoots>();
        shootingCoroutine = ShootingRoutine();
    }

    private void StartShootingRoutine()
    {
        StartCoroutine(shootingCoroutine);
    }

    IEnumerator ShootingRoutine()
    {
        // Bắn 3s 1 lần 
        while (true)
        {
            ShootFromAllGuns();
            yield return new WaitForSeconds(3f);
        }
    }

    private void ShootFromAllGuns()
    {
        // Bắn từ tất cả các súng
        foreach (var gun in guns)
        {
            gun.ShootBullet(facingRight, false); //dùng biến facingRight để điều khiển chiều bắnbắn
        }
    }
}
