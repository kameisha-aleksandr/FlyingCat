using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Hero))]

public class HeroCollisionHandler : MonoBehaviour
{
    private Hero _hero;
    private HeroMover _heroMover;
    private GameObject _tmpGO;
    private bool _isPlatformCrossed = false;

    void Awake()
    {
        _hero = GetComponent<Hero>();
        _heroMover = GetComponent<HeroMover>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
            _hero.Die();

        if (collision.gameObject.tag == "ground")
        {
            if(!_isPlatformCrossed && _tmpGO != null && collision.gameObject!=_tmpGO)
            {
                _isPlatformCrossed = true;             
            }
            else if (collision.gameObject == _tmpGO && _isPlatformCrossed)
            {
                _hero.IncreaseScore();
                _isPlatformCrossed = false;
                _heroMover.SetExtraJumps();
            }
            else if (collision.gameObject == _tmpGO || _isPlatformCrossed)
            {
                _heroMover.SetExtraJumps();
            }     
            _tmpGO = collision.gameObject;
        }
    }
}
