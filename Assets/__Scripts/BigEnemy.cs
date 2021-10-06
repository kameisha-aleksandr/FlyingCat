using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
    private float _leftPosX, _rightPosX;
    
    void Start()
    {
        _leftPosX = -Main.camWidth + _enemyWidth / 2;
        _rightPosX = Main.camWidth - _enemyWidth / 2;

        if (Random.value >= 0.5f)
            transform.position = new Vector3(_rightPosX, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(_leftPosX, transform.position.y, transform.position.z);
    }
}
