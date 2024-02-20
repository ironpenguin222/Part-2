using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 destination;
    public float speed = 3;
    public float minDistance = 0.1f; // Stops the player from vibrating by making the player have a minimum amount of distance needed

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Makes player move to destination
        Vector2 movement = destination - (Vector2)transform.position;


        // Checks and then moves the player and alerts game to get direction
        if (movement.magnitude > minDistance)
        {
            rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
            DetectDirection(movement);
        }
        else
        {
            // Idle animation
            anim.SetFloat("Speed", 0f);
        }
    }

    void Update()
    {

        // Takes position of mouse to make destination

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination = new Vector2(mousePosition.x, mousePosition.y);
        }
    }

    void DetectDirection(Vector2 movement)
    {
        float angle = Vector2.SignedAngle(Vector2.right, movement.normalized);

        if (angle > -45 && angle <= 45)
        {
            // Moving right
            anim.SetFloat("Horizontal", 1f);
            anim.SetFloat("Vertical", 0f);
        }
        else if (angle > 45 && angle <= 135)
        {
            // Moving up
            anim.SetFloat("Horizontal", 0f);
            anim.SetFloat("Vertical", 1f);
        }
        else if (angle > 135 || angle <= -135)
        {
            // Moving left
            anim.SetFloat("Horizontal", -1f);
            anim.SetFloat("Vertical", 0f);
        }
        else
        {
            // Moving down
            anim.SetFloat("Horizontal", 0f);
            anim.SetFloat("Vertical", -1f);

        }

        // Set Speed parameter to control the walking animation
        anim.SetFloat("Speed", 1f);
    }
}
