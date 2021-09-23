using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
    private SpriteRenderer _spriteRenderer;
    private float _leftPosX, _rightPosX;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        var spriteRadius = _spriteRenderer.bounds.size.x / 2;
        _leftPosX = -Main.camWidth + spriteRadius;
        _rightPosX = Main.camWidth - spriteRadius;

        if (Random.value >= 0.5f)
            transform.position = new Vector3(_rightPosX, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(_leftPosX, transform.position.y, transform.position.z);
    }
}
