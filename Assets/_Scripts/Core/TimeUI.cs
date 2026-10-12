using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
