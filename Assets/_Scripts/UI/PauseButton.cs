using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    public void OnPauseButton()
    {
        AudioManager.Instance.PlayButtonSound();
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
