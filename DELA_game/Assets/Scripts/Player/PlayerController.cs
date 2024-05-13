using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public UnityEvent onEnemyCollision;
    public UnityEvent onChestCollision;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

    }
    public void Move(Vector3 movement)
    {
        rb.velocity = (movement * speed);
    }

    public void StopMovement()
    {
        rb.isKinematic = true;
    }
}

