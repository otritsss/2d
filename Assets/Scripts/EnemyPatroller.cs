using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]

public class EnemyPatroller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToChangeDirection;

    private Rigidbody2D _rigidbody2D;
    private float _runningTime;
    private SpriteRenderer _renderer;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Movement());
    }

    private IEnumerator Movement()
    {
        while(true)
        {
            _runningTime += Time.deltaTime;

            if (_runningTime < _timeToChangeDirection)
            {
                _rigidbody2D.velocity = -transform.right * _speed;
                _renderer.flipX = false;
            }
            else
            {
                _rigidbody2D.velocity = transform.right * _speed;
                _renderer.flipX = true;
            }                

            if (_runningTime > _timeToChangeDirection * 2)
                _runningTime = 0;

            yield return null;
        }
    }
}
