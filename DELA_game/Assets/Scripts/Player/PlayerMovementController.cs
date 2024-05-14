using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Essentials
    public Transform cam;
    CharacterController controller;
    float turnSmoothTime = .1f;
    float turnSmoothVelocity;
    Animator anim;

    //Movement
    Vector2 movement;
    public float moveSpeed;

    //Jumping
    public float jumpHeight;
    public float gravity;
    bool isGrounded;
    bool hasJumped = false;
    Vector3 velocity;

    public GameObject[] uiPanels;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("HasJumped", hasJumped);
    }

    private void Update()
    {
        



        
        bool isUIActive = false;
        foreach (GameObject panel in uiPanels)
        {
            if (panel.activeSelf)
            {
                isUIActive = true;
                return;
            }
            else
            {
                isUIActive = false;
            }
        }

        if (!isUIActive)
        {
            isGrounded = Physics.CheckSphere(transform.position, .1f, 1);
            anim.SetBool("IsGrounded", isGrounded);
            if (isGrounded)
            {
                hasJumped = false;
            }




            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -1;
            }

            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);

                anim.SetFloat("Speed", 1);
            }
            else
            {
                anim.SetFloat("Speed", 0);
            }

            //jumping
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);
                hasJumped = true;
            }

            if (velocity.y > -20)
            {
                velocity.y += (gravity * 10) * Time.deltaTime;
            }

            controller.Move(velocity * Time.deltaTime);
            anim.SetBool("HasJumped", hasJumped);

            if(gameObject.transform.position.y < -2)
            {
                gameObject.transform.position = new Vector3(0, 2, 0);
            }

        }
    }
}