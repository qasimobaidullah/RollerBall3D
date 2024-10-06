using UnityEngine;

public class AdvancedBallController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public float groundCheckDistance = 0.6f;  // Distance for raycast to check if the ball is grounded
    public LayerMask groundLayer;              // Layer mask for the ground
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Movement input from WASD keys and Arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");  // Handles A/D and Left/Right Arrow
        float moveVertical = Input.GetAxis("Vertical");      // Handles W/S and Up/Down Arrow

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * moveSpeed);

        // Jump input using Space bar or Up Arrow
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Method to check if the ball is grounded using Raycast with Layer Mask
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}
