using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component attached to this GameObject
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  // Get input from horizontal axis (A/D, Left/Right Arrow)
        float moveVertical = Input.GetAxis("Vertical");  // Get input from vertical axis (W/S, Up/Down Arrow)

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);  // Create a Vector3 movement vector
        movement.Normalize();

        rb.velocity = movement * speed;  // Apply the movement vector as a force to the Rigidbody
    }
}