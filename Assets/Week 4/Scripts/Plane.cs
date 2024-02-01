using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rb;
    public float speed = 1;
    public AnimationCurve landing;
    public float landingTimer;
    public float tooClose;
    private float planesInRange;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
        }
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        planesInRange++;
            CheckPlane(other);
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        planesInRange--;

        if (planesInRange == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
       
    }


    private void CheckPlane(Collider2D other)
    {
        GetComponent<SpriteRenderer>().color = Color.red;

        float distance = Vector3.Distance(transform.position, other.transform.position);

        if (distance < tooClose)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
       
        if(Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.2f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.z < 0.1f) {
                Destroy(gameObject);
              }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                if(lineRenderer.positionCount !=0) {
                    lineRenderer.positionCount--;
                }
               
            }
        }
    }

    private void OnMouseDown()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points = new List<Vector2>();
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Vector2.Distance(newPosition, lastPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount ++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
     
    }
 

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
