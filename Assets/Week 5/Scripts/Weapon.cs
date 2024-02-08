using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   Rigidbody2D rb;
   public float speed = 5f;
   public float damage = 1f;
   public float timeDestroy = 5f;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       rb.velocity = transform.right * speed;
       Invoke("DestroyWeapon", timeDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
        collision.gameObject.SendMessage("TakeDamage", 1);
        Destroy(gameObject);
    }
    }

    private void DestroyWeapon()
    {
        Destroy(gameObject);
    }
}