using UnityEngine;
using System.Collections;

public class Bullets_Manager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Death());
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        // Xóa đạn sau 2 giây
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        // Xóa đạn khi va chạm với Player hoặc Ground
    }
}
