using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMover : EdgeToEdgeMover
{
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private Vector3 _startPosition;
    
    private int _extraJumps = 2;
 
    private void Awake()
    {
        Init(3f);
        ResetHero();
    }
    private void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0) && _extraJumps > 0)
        {
            Jump();
            _extraJumps--;
        }
    }
    public void ResetHero()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
        SetExtraJumps();
    }
    public void SetExtraJumps()
    {
        _extraJumps = 2;
    }
    private void Jump()
    {
        if (_rigidbody.velocity.y > _tapForce/2)
            _rigidbody.velocity = Vector2.up * _tapForce*1.1f;
        else
            _rigidbody.velocity = Vector2.up * _tapForce;
    }
}
