using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingObject : MonoBehaviour
{
    public float spinSpeed = 25f; // Speed of spinning
    public float bounceHeight = 0.1f; // Max height of bouncing
    public float bounceSpeed = 1.5f; // Speed of bouncing

    private Vector3 startPos;
    private bool isDisabled;

    private bool isInvisible = false; 

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its up axis
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);

        // Calculate bouncing motion using sine wave
        float bounce = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        // Update the object's position
        transform.position = startPos + new Vector3(0f, bounce, 0f);
    }

    public void SetInvisible()
    {
        if (!isDisabled)
        {
            if (isInvisible)
            {
                gameObject.SetActive(true);
                isInvisible= false;
            } else
            {
                gameObject.SetActive(false);
                isInvisible= true;
            }
        }
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
        isDisabled = true;
    }
}
