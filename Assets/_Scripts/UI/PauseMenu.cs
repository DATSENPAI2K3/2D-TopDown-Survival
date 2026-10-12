using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public void Resume()
    {
        AudioManager.Instance.PlayButtonSound();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void Restart()
    {
        AudioManager.Instance.PlayButtonSound();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        AudioManager.Instance.PlayButtonSound();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
