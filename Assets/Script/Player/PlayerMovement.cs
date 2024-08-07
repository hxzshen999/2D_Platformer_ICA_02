using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _maxHorizontalSpeed = 10f;

    [Header("Spring Multiplier")]
    [SerializeField] float _springMultiplier = 2;

    [Header("Jump")]
    [SerializeField] float _jumpForce = 10f;
    [SerializeField] float _fallGravityScale = 2.5f;
    [SerializeField] float _normalGravityScale = 1f;
    [SerializeField] float _groundCheckRadius = 0.2f;
    [SerializeField] Transform _groundCheck; 
    [SerializeField] LayerMask _groundLayer;

    [Header("Player Input")]
    private Vector2 _playerInputDir;
    private Vector2 _LastPlayerInputDir;

    private Rigidbody2D _rb2d;
    private bool _isGrounded;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Update _playerInputDir based on input
        _playerInputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Check if grounded
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

        // Handle jump input
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
        }

        // Adjust gravity scale based on whether the player is grounded
        _rb2d.gravityScale = _isGrounded ? _normalGravityScale : _fallGravityScale;
    }

    void FixedUpdate()
    {
        // Move the player in FixedUpdate to handle frame rate variations
        MovePlayer();
    }

    private void FlipPlayerSprite()
    {
        if (_playerInputDir.x != 0)
        {
            _LastPlayerInputDir = _playerInputDir.normalized;
        }

        if (_LastPlayerInputDir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_LastPlayerInputDir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void MovePlayer()
    {
        float horizontalInput = _playerInputDir.x;

        // Calculate the movement direction and apply the speed
        Vector3 movement = new Vector3(horizontalInput, 0, 0) * _moveSpeed * Time.fixedDeltaTime;

        // Limit the maximum horizontal speed
        movement.x = Mathf.Clamp(movement.x, -_maxHorizontalSpeed, _maxHorizontalSpeed);

        // Update position
        Vector3 newPosition = transform.position + movement;

        transform.position = newPosition;

        FlipPlayerSprite();
    }

    private void Jump()
    {
        // Apply vertical force for jumping
        _rb2d.velocity = new Vector2(_rb2d.velocity.x, _jumpForce);
        AudioManager.Instance.PlaySFX("Pick_Up");
    }
}
