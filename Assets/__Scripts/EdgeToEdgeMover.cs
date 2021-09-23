using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EdgeToEdgeMover : MonoBehaviour
{ 
    [SerializeField] private float _speed;
    
    private float _radius;
    private int _dir=1;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _radius = _spriteRenderer.sprite.bounds.size.x * transform.localScale.x / 2;
    }

    void FixedUpdate()
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
        _rigidbody.velocity = new Vector2(_speed*_dir, _rigidbody.velocity.y);
    } 
}
