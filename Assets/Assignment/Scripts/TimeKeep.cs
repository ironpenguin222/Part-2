using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeKeep : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText;

    private void Start()
    {
        // Retrieve the game end time from PlayerPrefs
        float gameEndTime = PlayerPrefs.GetFloat("GameEndTime", 0f);

        // Display the total survival time using text
        finalTimeText.text = "Total Time: " + gameEndTime.ToString("F2");
    }
    }