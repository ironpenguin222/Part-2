using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float initialSpawnTime = 5f;
    public float minSpawnInterval = 1f;
    private float currentSpawnTime;
    private float timer;
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    void Start()
    {
        currentSpawnTime = initialSpawnTime;
    }

    void Update()
    {
        // Timer
        timer += Time.deltaTime;

        if (timer >= currentSpawnTime)
        {
            SpawnBullet();
            timer = 0f;
            currentSpawnTime = Mathf.Max(minSpawnInterval, currentSpawnTime - 0.1f);
        }
    }

    void SpawnBullet()
    {
        // Spawns bullets on random part of map and instantiates
        float randomAngle = Random.Range(0f, 360f);
        Vector3 spawnPosition = GetRandomPositionOnMap(randomAngle);
        Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomPositionOnMap(float angle)
    {
        // Generating random position on map to spawn bullets
        float randomDistance = Random.Range(0f, 20f);
        Vector3 randomPosition = transform.position + Quaternion.Euler(0f, 0f, angle) * Vector3.right * randomDistance;

        // Makes sure that bullets spawn in map
        randomPosition.x = Mathf.Clamp(randomPosition.x, minX, maxX);
        randomPosition.y = Mathf.Clamp(randomPosition.y, minY, maxY);

        return randomPosition;
    }
}
