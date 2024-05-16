using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    public CollectibleType type;
    public String text;
    public CollectibleManager collectibleManager;

    public float spinSpeed = 25f; // Speed of spinning
    public float bounceHeight = 0.1f; // Max height of bouncing
    public float bounceSpeed = 1.5f; // Speed of bouncing

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Rotate the object around its up axis
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

        // Calculate bouncing motion using sine wave
        float bounce = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        // Update the object's position
        transform.position = startPos + new Vector3(0f, bounce, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play a pickup sound
            AudioManager.Instance.PlaySound("PickupCollectibleSound");

            // Add collectible to the collectible manager list
            if (type == CollectibleType.Response)
            {
                collectibleManager.addResponse(this);
            }
            else if (type == CollectibleType.Tip)
            {
                collectibleManager.addTip(this);
            }

            collectibleManager.UpdateCollectableCanvas();

            // Destroy the collectible
            gameObject.SetActive(false);
        }
    }
}

public enum CollectibleType
{
    Response,
    Tip
}