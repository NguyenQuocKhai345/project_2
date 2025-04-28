using UnityEngine;

public class Mace2 : MonoBehaviour
{
    public float speed = 1.5f;
    int dir = 1;
    public Transform rightCheck;
    public Transform leftCheck;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime * dir);
        if (Physics2D.Raycast(transform.position, Vector2.right, 0.5f, LayerMask.GetMask("Check")))
        {
            dir = -1; // Đổi hướng sang trái
        }

        // Kiểm tra va chạm với leftCheck
        if (Physics2D.Raycast(transform.position, Vector2.left, 0.5f, LayerMask.GetMask("Check")))
        {
            dir = 1; // Đổi hướng sang phải
        }

    }
}
