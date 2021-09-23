using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTracker : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private float _yOffset;

    public void StartGame()
    {
        _yOffset = -3;
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, _hero.transform.position.y - _yOffset, transform.position.z);
    }
}
