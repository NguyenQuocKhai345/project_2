using UnityEngine;
using System.Collections;
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
            AudioManager.instance.Play("Coin"); // Play coin sound
        }
        else if (collision.CompareTag("Trap"))
        {
            PlayerHealth.health--;
            if (PlayerHealth.health <= 0)
            {
                StartCoroutine(HandleTrapCollision());
            }
        }
        else if (collision.CompareTag("Bullet"))
        {
            PlayerHealth.health--;
            if (PlayerHealth.health <= 0)
            {
                StartCoroutine(HandleTrapCollision());
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Gai"))
        {
            PlayerHealth.health--;
            if (PlayerHealth.health <= 0)
            {
                StartCoroutine(HandleTrapCollision());
            }
        }
    }

    private System.Collections.IEnumerator HandleTrapCollision()
    {
        yield return new WaitForSeconds(0.3f); // Wait for 2 seconds
        gameManager.GameOver(); // Call GameOver method in GameManager
        AudioManager.instance.Play("GameOver"); // Play GameOver sound
    }
}
