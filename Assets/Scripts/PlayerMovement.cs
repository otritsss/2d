using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _renderer;
    private float _currentSpeed;
    private const string _playerSpeed = "speed";
    private bool _isGrounded = true;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody2D.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        //CheckGround();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _currentSpeed = _speed * Time.deltaTime;
            transform.Translate(_currentSpeed, 0, 0);
            _animator.SetFloat(_playerSpeed, _currentSpeed);
            _renderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _currentSpeed = _speed * Time.deltaTime;
            transform.Translate(_currentSpeed * -1, 0, 0);
            _animator.SetFloat(_playerSpeed, _currentSpeed);
            _renderer.flipX = true;
        }

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    //private void CheckGround()
    //{
    //    Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
    //    _isGrounded = collider.Length > 1;
    //}
}
