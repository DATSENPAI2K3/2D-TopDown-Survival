using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    public void Restart()
    {
        AudioManager.Instance.PlayButtonSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
        gameObject.SetActive(false);
    }
    public void GameOverQuit()
    {
        AudioManager.Instance.PlayButtonSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        gameObject.SetActive(false);
    }
}
