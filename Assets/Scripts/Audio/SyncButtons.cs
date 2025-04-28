using UnityEngine;
using UnityEngine.UI;

public class SyncButtons : MonoBehaviour
{
    public Button muteButton; // Gắn nút tắt nhạc từ Inspector
    public Button playButton; // Gắn nút bật nhạc từ Inspector

    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SyncButtons(muteButton, playButton);
        }
    }
}