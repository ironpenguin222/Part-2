using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnim : MonoBehaviour
{
    public RectTransform targetRectTransform;
    public Vector2 targetPosition;
    public float lerpSpeed = 2f;

    private void Start()
    {
        // Set the initial position of the target to 0
        targetRectTransform.anchoredPosition = Vector2.zero;
    }

    private void Update()
    {
        // Use Mathf.Lerp to move the target to the destination
        targetRectTransform.anchoredPosition = Vector2.Lerp(targetRectTransform.anchoredPosition, targetPosition, lerpSpeed * Time.deltaTime);
    }
}



