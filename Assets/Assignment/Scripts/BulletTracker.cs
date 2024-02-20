using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletTracker : MonoBehaviour
{
    public Slider bar;
    public TextMeshProUGUI bulletCounting;
    float bulletCount = 15;

    private void Start()
    {
        // Setups the starting UI
        bulletCounting.text = 15 + " / 15";

    }
    public void Shot(float bullets)
    {

        // Updates UI after bullets are shot
        bulletCount -= bullets;
        bar.value -= bullets;
        if (bulletCount > 15)
        {
            bulletCount = 15;
            bulletCounting.text = Mathf.Round(bulletCount).ToString() + " / 15";
        }
        else
        {
            bulletCounting.text = Mathf.Round(bulletCount).ToString() + " / 15";
        }
    }
}
