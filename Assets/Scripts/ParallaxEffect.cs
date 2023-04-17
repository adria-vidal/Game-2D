using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier;
    private Transform cameraTransform;
    private Vector3 previousCameraPosition;
    private float spriteWidth, currentPosition;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        currentPosition = transform.position.x;
    }
    void Update()
    {
        float moveAmount = cameraTransform.position.x * (1 - parallaxMultiplier);
        if (moveAmount > currentPosition + spriteWidth)
        {
            currentPosition += spriteWidth;
            transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
        }
        else if (moveAmount < currentPosition - spriteWidth)
        {
            currentPosition -= spriteWidth;
            transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
        }
    }
    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x) * parallaxMultiplier;
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = cameraTransform.position;
    }
}
