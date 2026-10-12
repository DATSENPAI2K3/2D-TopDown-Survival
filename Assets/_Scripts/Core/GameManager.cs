using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject gameOver;
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void GameOver()
    {
        this.gameOver.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("GAME OVER");
    }
}
