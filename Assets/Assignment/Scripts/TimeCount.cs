using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class TimeCount : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float increase = 1f;

    private float currentValue;

    void Start()
    {
        currentValue = 0f;
        ResetPlayerPrefs();
    }

    void Update()
    {
        // Increase the value over time
        currentValue += increase * Time.deltaTime;

        // Update the TextMeshPro text
        timer.text = "Time: " + Mathf.Round(currentValue).ToString();
    }
        public static void ResetPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs reset");
        }

        private void GameOver()
    {
        // Capture the game end time
        float gameEndTime = Time.time;

        // Save the game end time to PlayerPrefs
        PlayerPrefs.SetFloat("GameEndTime", gameEndTime);
        PlayerPrefs.Save();

    }

}
