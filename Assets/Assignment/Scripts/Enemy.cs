using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 3f;
    public float rotationSpeed = 5f;


    private void Start()
    {
        //sets up the player for the enemies
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
  
    void Update()
    {

        // Calculate the direction towards the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Calculate the rotation to face the player
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, directionToPlayer);

        // Gradually rotate towards the player
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Move towards the player
        transform.Translate(Vector3.up * chaseSpeed * Time.deltaTime);



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
