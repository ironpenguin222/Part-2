using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    public Slider bar;

    public void Damage(float damage)
    {
        // Updates health bar UI when player gets hit
        bar.value -= damage;
    }
}
