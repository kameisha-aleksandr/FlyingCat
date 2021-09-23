using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMover : MonoBehaviour
{
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private int _extraJumps = 2;
    private Rigidbody2D _rigidbody;

    public void ResetHero()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
        SetExtraJumps();
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        ResetHero();
    }
    public void SetExtraJumps()
    {
        _extraJumps = 2;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _extraJumps > 0)
        {
            Jump();
            _extraJumps--;
        }
    }
    private void Jump()
    {
        if (_rigidbody.velocity.y > _tapForce/2)
            _rigidbody.velocity = Vector2.up * _tapForce*1.1f;
        else
            _rigidbody.velocity = Vector2.up * _tapForce;
    }
}
