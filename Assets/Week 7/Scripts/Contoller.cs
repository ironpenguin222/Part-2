using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoller : MonoBehaviour
{
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


}
