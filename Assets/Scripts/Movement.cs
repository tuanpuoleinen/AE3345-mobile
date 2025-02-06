// This component should be added to the Player object
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    private float moveSpeed = 5f;
    private float jumpForce = 8f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Button jumpButton;

    private Rigidbody2D rB;
    private bool isGrounded;

    void Start()
    {
        rB = GetComponent<Rigidbody2D>();

        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager != null)
        {
            gameOverManager.SetRigidbody(rB);  // Pass the Rigidbody2D to GameOverManager
        }

        if (jumpButton != null)
        {
            jumpButton.onClick.AddListener(Jump);
        }
    }

    void Update()
    {

        Vector2 moveDirection = moveAction.action.ReadValue<Vector2>();

        rB.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rB.linearVelocity.y);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rB.linearVelocity = new Vector2(rB.linearVelocity.x, jumpForce);
        }
    }

    // Checker for character location to be on the groundLayer (floor)
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.red);
        return hit.collider != null;
    }
}