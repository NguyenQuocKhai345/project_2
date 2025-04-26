using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    private GameManger gameManager; // Reference to the GameManager script
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManger>(); // Find the GameManager in the scene
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject); // Destroy the coin object
            gameManager.AddScore(1); // Add score when the player collides with a coin
        }
        else if (collision.CompareTag("Trap"))
        {
            StartCoroutine(HandleTrapCollision()); // Start coroutine for trap collision
        }
    }

    private System.Collections.IEnumerator HandleTrapCollision()
    {
        yield return new WaitForSeconds(0.5f); // Wait for 2 seconds
        gameManager.GameOver(); // Call GameOver method in GameManager
    }
}
