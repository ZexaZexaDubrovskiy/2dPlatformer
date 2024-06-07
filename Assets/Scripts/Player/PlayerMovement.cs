using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Vector3 _groundCheckOffset;
    [SerializeField] private LayerMask _groundMask;

    private Vector3 _input;
    private Rigidbody2D _rb;
    private PlayerAnimations _anim;
    private bool _isMoving;
    private bool _isGrounded;
    private bool _isFlying;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
            if (_isGrounded)
                Jump();

        _anim.IsMoving = _isMoving;
        _anim.IsGrounded = _isGrounded;
        _anim.IsFlying = IsFlying();

    }

    private void Move()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _speed * Time.deltaTime;
        if (_input.x != 0)
        {
            _playerSprite.flipX = _input.x > 0 ? false : true;
            _isMoving = true;
        }
        else 
            _isMoving = false;
    }

    private bool IsFlying() => _rb.velocity.y < 0 ? true : false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) 
            _isGrounded = true;
        else 
            _isGrounded = false;
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        _anim.Jump();
    }


}
