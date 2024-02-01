using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject planePrefab;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= Random.Range(1f, 5f))
        {
            SpawnPlane();
            timer = 0f;
        }
    }

    void SpawnPlane()
    {
        GameObject newPlane = Instantiate(planePrefab);

        float planeX = Random.Range(-5f, 5f);
        float planeY = Random.Range(-5f, 5f);
        newPlane.transform.position = new Vector2(planeX, planeY);
        float randomZRotation = Random.Range(0f, 360f);
        newPlane.transform.rotation = Quaternion.Euler(0f, 0f, randomZRotation);
        float speed = Random.Range(1f, 3f);
        newPlane.GetComponent<Plane>().speed = speed;
    }
}
