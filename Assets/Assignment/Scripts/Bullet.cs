using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifetime = 2f;

    void Start()
    {
        // Destroy the bullet after some time
        Destroy(gameObject, bulletLifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // Destroys anything on hit other than player
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }
}
