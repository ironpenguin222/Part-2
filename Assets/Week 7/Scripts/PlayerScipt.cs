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
    public Rigidbody2D rb;
    public float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Selected(false);
    }

    private void OnMouseDown()
    {
        Contoller.SetCurrentSelection(this);
    }


    public void Selected(bool isSelected)
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

    public void Move(Vector2 direction)
    {
      rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
