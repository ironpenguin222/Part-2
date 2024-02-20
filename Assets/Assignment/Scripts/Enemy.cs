using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 3f;

    private void Start()
    {
        //sets up the player for the enemies
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
  
    void Update()
    {

            // Calculate the direction towards the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Normalize the direction to get a unit vector
            Vector3 normalizedDirection = directionToPlayer.normalized;

            // Move towards the player at a constant speed
            transform.Translate(normalizedDirection * chaseSpeed * Time.deltaTime);

            
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if it's touching player, and deals damage if it is
        if (other.CompareTag("Player"))
        {
            other.SendMessage("Damage", 1);
            Destroy(gameObject);
        }
    }
}
