using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoller : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge;
    Vector2 direction;
    public static PlayerScipt currentSelection { get; private set; }

    public static void  SetCurrentSelection(PlayerScipt player)
    {
        if(currentSelection != null)
        {
            currentSelection.Selected(false);
        }
        currentSelection = player;
        currentSelection.Selected(true);
    }

    private void FixedUpdate()
    {
        if(direction != Vector2.zero)
        {
            currentSelection.Move(direction);
            direction = Vector2.zero;
        }
    }

    public void Update()
    {
        if (currentSelection == null) return;

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            charge = 0;
            direction = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
            chargeSlider.value = charge;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)(currentSelection.transform.position).normalized * charge);
        }
    }

}
