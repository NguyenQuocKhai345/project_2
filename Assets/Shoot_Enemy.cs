using UnityEngine;
using System.Collections;

public class Shoot_Enemy : MonoBehaviour
{
    IEnumerator shootingCoroutine;
    Rigidbody2D enemyRigidbody;
    Shoots[] guns;
    public static Shoot_Enemy instance;

    [Header("Shooting Settings")]
    public bool facingRight = true; // <-- thêm biến public chọn hướng

    void Awake()
    {
        //EnsureSingletonInstance();
    }

    void Start()
    {
        InitializeComponents();
        StartShootingRoutine();
    }

    // private void EnsureSingletonInstance()
    // {
    //     if (instance && instance != this)
    //     {
    //         Destroy(this.gameObject);
    //     }
    //     else
    //     {
    //         instance = this;
    //     }
    // }

    private void InitializeComponents()
    {
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
        while (true)
        {
            ShootFromAllGuns();
            yield return new WaitForSeconds(2f);
        }
    }

    private void ShootFromAllGuns()
    {
        foreach (var gun in guns)
        {
            gun.ShootBullet(facingRight); // <-- dùng biến facingRight
        }
    }
}
