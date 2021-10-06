using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EdgeToEdgeMover : MonoBehaviour
{ 
    [SerializeField] protected float _speed;

    protected float _radius;
    protected int _dir=1;
    protected Rigidbody2D _rigidbody;
    protected SpriteRenderer _spriteRenderer;

    protected void Init(float speed)
    {
        _speed = speed;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _radius = _spriteRenderer.sprite.bounds.size.x * transform.localScale.x / 2;
    }
    protected void Move()
    {
        if (transform.position.x > Main.camWidth - _radius)
        {
            _dir = -1;
            _spriteRenderer.flipX = true;
        }
        if (transform.position.x < -Main.camWidth + _radius)
        {
            _dir = 1;
            _spriteRenderer.flipX = false;
        }
        _rigidbody.velocity = new Vector2(_speed * _dir, _rigidbody.velocity.y);
    }
    private void Awake()
    {
        Init(5f);
    }

    private void Update()
    {
        Move();
    } 
}
