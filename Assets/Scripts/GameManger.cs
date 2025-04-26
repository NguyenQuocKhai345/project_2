using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour
{
    private int score = 0; // Player's score
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    private bool isGameOver = false; // Flag to check if the game is over
    void Start()
    {
        UpdateScoreText();
        gameOverPanel.SetActive(false);
        // Update is called once per frame
    }
    void Update()
    {

    }
    public void AddScore(int points)
    {
        score += points; // Add points to the score
        UpdateScoreText();
    }
    public void UpdateScoreText()
    {
        scoreText.text = score.ToString(); // Update the score text in the UI
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0; // Reset the score to 0
        Time.timeScale = 0; // Pause the game
        gameOverPanel.SetActive(true); // Show the game over panel
    }
    public void RestartGame()
    {
        isGameOver = false;
        Time.timeScale = 1; // Resume the game
        score = 0; // Reset the score to 0
        UpdateScoreText(); // Update the score text in the UI
        SceneManager.LoadScene(1); // Reload the current scene
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0); // Load the menu scene
    }
}
