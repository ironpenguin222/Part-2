using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionChanger : MonoBehaviour
{

    public void SetResolution()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
    }

    public void SetResolutionToHD()
    {
        Screen.SetResolution(1280, 720, Screen.fullScreen);
    }
}
