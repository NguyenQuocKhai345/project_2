using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject largeBall; // Prefab của quả cầu (phải là 2D Sprite)
    public float speed = 5099f; // Tốc độ di chuyển của quả cầu
    private GameObject spawnedBall;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger!");

            // Spawn quả cầu tại vị trí cố định
            Vector3 spawnPosition = new Vector3(135.44f, 7.14f, 0f); // Z = 0 cho 2D
            spawnedBall = Instantiate(largeBall, spawnPosition, Quaternion.identity);

            // Lấy Rigidbody2D của quả cầu
            Rigidbody2D rb = spawnedBall.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Đẩy quả cầu sang trái
                Vector2 direction = Vector2.left; // Hướng cố định sang trái
                rb.linearVelocity = direction * speed; // Sử dụng linearVelocity để di chuyển
            }
            else
            {
                Debug.LogError("Không tìm thấy Rigidbody2D trên largeBall prefab!");
            }
        }
    }
}
