using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public static GameObject playerInstance;

    public float moveSpeed = 3.0f;
    float horizontalInput = 0;
    float verticalInput = 0;
    public bool canMove = true;  // Allow movement by default
    Vector3 movement;
    public Animator animator;

    private void Awake()
    {
        if (playerInstance == null)
        {
            playerInstance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (!canMove)
        {
            // If canMove is false, don't allow movement
            movement = Vector3.zero;
        }
        else
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                horizontalInput = 0;
                verticalInput = Input.GetAxis("Vertical");
                movement = new Vector3(horizontalInput, verticalInput, 0);
                transform.Translate(movement * moveSpeed * Time.deltaTime);

            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                verticalInput = 0;
                horizontalInput = Input.GetAxis("Horizontal");
                movement = new Vector3(horizontalInput, verticalInput, 0);
                transform.Translate(movement * moveSpeed * Time.deltaTime);
            }
            else
            {
                movement = new Vector3(0, 0, 0);
            }
        }

        if (movement != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("moveX", horizontalInput);
            animator.SetFloat("moveY", verticalInput);

        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    // Add this function to externally control the ability to move
    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
