using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.VersionControl;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 10f;
    float bulletAmount = 15;

    void Update()
    {
        if (bulletAmount > 15)
        {

            bulletAmount = 15;
        }

        // Check for right click
        if (Input.GetMouseButtonDown(1) && bulletAmount > 0)
        {
            SendMessage("Shot", 1);

            // Calculate the direction from the mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - bulletSpawn.position).normalized;

            // Spawn a bullet at the spawn point
            ShootBullet(direction);
        }
    }

    void Shot(float bullets)
    {
        bulletAmount -= bullets;
    }

    void ShootBullet(Vector2 direction)
    {
        // Instantiate the bullet prefab at the spawn position
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // Apply force to the bullet in the specified direction with constant speed
        bulletRb.velocity = direction.normalized * bulletSpeed;
    }
}
