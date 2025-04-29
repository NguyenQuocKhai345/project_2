using UnityEngine;

public class BallTrapLeft : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển của quả cầu

    private Rigidbody2D rb;

    void Start()
    {
        // Lấy Rigidbody2D của quả cầu
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Đặt vận tốc để quả cầu tự động di chuyển sang trái
            rb.linearVelocity = Vector2.left * speed;
        }
        else
        {
            Debug.LogError("Không tìm thấy Rigidbody2D trên LargeBall!");
        }
    }
}
