using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void Initilization(float health)
    {
        slider.value = health;
    }

    public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }
  
}
