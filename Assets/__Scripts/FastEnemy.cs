using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _Attention;

    private Vector3 startPosition;
    private Rigidbody2D _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        startPosition = new Vector3(-Main.camWidth - _enemyWidth, transform.position.y, 0);
        transform.position = startPosition;
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveRight()
    {
        while (true)
        {
            if (transform.position.x > Main.camWidth + _enemyWidth)
            {
                transform.position = startPosition;
                _rigidbody.velocity = Vector2.zero;
            }
            yield return new WaitForSeconds(_delay-1);
            _Attention.SetActive(true);
            yield return new WaitForSeconds(1);
            _Attention.SetActive(false);
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        }      
    }
}
