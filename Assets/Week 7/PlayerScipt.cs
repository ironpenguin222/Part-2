using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EditorTools;

public class PlayerScipt : MonoBehaviour
{
    bool isSelected = false;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        isSelected = true;
        Selected();
    }


    public void Selected()
    {
        if (isSelected == true)
        {
            spriteRenderer.color = Color.red;

        }
        else
        {
            spriteRenderer.color = Color.magenta;
        }
    }
  
    void Update()
    {
    }
}
