using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour
{
    private int score = 0; // Player's score
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;
    [SerializeField] private GameObject beginPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject buttonPause;

    void Start()
    {
        UpdateScoreText();
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        beginPanel.SetActive(true);
        buttonPause.SetActive(true);
        StartCoroutine(HideBeginPanelAfterDelay(3f));
        // Update is called once per frame
    }
    void Update()
    {

    }

    private System.Collections.IEnumerator HideBeginPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Chờ 2 giây
        beginPanel.SetActive(false); // Ẩn beginPanel
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
        score = 0; // Reset the score to 0
        Time.timeScale = 0; // Pause the game
        gameOverPanel.SetActive(true); // Show the game over panel
        buttonPause.SetActive(false);
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Stop("BackGround");
        }
    }
    public void GameWin()
    {
        Time.timeScale = 0; // Pause the game
        pausePanel.SetActive(false);
        gameWinPanel.SetActive(true); // Show the game over panel
        buttonPause.SetActive(false);
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Stop("BackGround");
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        score = 0;
        UpdateScoreText();
        SceneManager.LoadScene(1);

        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("BackGround");
            AudioManager.instance.SetMusicState(true); // <-- thêm dòng này
            AudioManager.instance.UpdateButtonStates(); // cập nhật lại nút
        }
    }
    public void BackToMenu()
    {
        Time.timeScale = 1; // Ensure the game is not paused
        SceneManager.LoadScene(0); // Load the menu scene
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("BackGround");
            AudioManager.instance.SetMusicState(true); // <-- thêm dòng này
            AudioManager.instance.UpdateButtonStates(); // cập nhật lại nút
        }
    }
    public void Pause(string sound)
    {
        Time.timeScale = 0; // Pause the game
        pausePanel.SetActive(true); // Hiện bảng tạm dừng

        // Tạm dừng nhạc nền thông qua AudioManager
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Pause("BackGround");
        }
    }
    public void Resume()
    {
        Time.timeScale = 1; // Resume the game
        pausePanel.SetActive(false); // Ẩn bảng tạm dừng

        // Tiếp tục phát nhạc nền thông qua AudioManager
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Resume("BackGround");
        }
    }
}
