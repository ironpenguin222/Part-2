using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    bool selfClick = false;
    public float health;
    public float maxHealth = 2;
    bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = maxHealth;
    }
    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;
        if(movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    void Update()
    {
        if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !selfClick)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        anim.SetFloat("movement", movement.magnitude);
    }
    private void OnMouseDown()
    {
        if (isDead) return;
        selfClick = true;
        TakeDamage(1);
    }

    private void OnMouseUp()
    {
        selfClick = false;
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if(health <= 0)
        {
            anim.SetTrigger("death");
            isDead = true;
        }
        else
        {
            isDead = false;
            anim.SetTrigger("TakeDamage");
        }
    }
}
