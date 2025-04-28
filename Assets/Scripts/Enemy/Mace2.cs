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
        if (Physics2D.Raycast(rightCheck.position, Vector2.down, 2f) == false)
        {
            dir = -1; // Reverse direction if hitting a wall
        }
        if (Physics2D.Raycast(leftCheck.position, Vector2.down, 2f) == false)
        {
            dir = 1; // Reverse direction if hitting a wall
        }

    }
}
