using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCount : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float increase = 1f;

    private float currentValue;

    void Start()
    {
        currentValue = 0f;
    }

    void Update()
    {
        // Increase the value over time
        currentValue += increase * Time.deltaTime;

        // Update the TextMeshPro text
        timer.text = "Time: " + Mathf.Round(currentValue).ToString();
    }
}
