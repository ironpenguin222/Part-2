using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Ghost;
    public float spawnInterval = 5f;
    public float spawnRadius = 5f;
    private float timer;

    void Update()
    {
        // Timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (timer >= spawnInterval)
        {
            // Spawn enemy at a random position around the player
            SpawnEnemy();


            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Calculate a random angle
        float randomAngle = Random.Range(0f, 360f);

        // Calculate a random position around the player within the specified radius to spawn ghost from
        Vector3 spawnPosition = transform.position + Quaternion.Euler(0f, 0f, randomAngle) * Vector3.right * spawnRadius;

        // Instantiate the ghost prefab at location
        Instantiate(Ghost, spawnPosition, Quaternion.identity);
    }
}
