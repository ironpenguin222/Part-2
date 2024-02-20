using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {

        // Restores 3 bullets for the player on collision
        if (other.CompareTag("Player"))
        {
            other.SendMessage("Shot", -3);
            Destroy(gameObject);
        }

    }
}
