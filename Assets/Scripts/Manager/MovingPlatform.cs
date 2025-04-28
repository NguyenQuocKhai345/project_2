using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    public float speed = 2f; // Speed of the platform movement
    private Vector3 target;
    void Start()
    {
        target = pointA.position; // Set the initial target to pointA
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime); // Move towards the target

        if (Vector3.Distance(transform.position, target) < 0.1f) // Check if close to the target
        {
            target = (target == pointA.position) ? pointB.position : pointA.position; // Switch target
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the player collides with the platform
        {
            collision.transform.SetParent(transform); // Set the player as a child of the platform
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the player exits the platform
        {
            collision.transform.SetParent(null); // Remove the player from the platform's hierarchy
        }
    }
}
