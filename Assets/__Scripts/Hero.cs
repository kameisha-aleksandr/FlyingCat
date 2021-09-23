using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HeroMover))]
public class Hero : MonoBehaviour
{
    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private int _score;
    private HeroMover _mover;
    private EdgeToEdgeMover _edgeToEdgeMover;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<HeroMover>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _edgeToEdgeMover = GetComponent<EdgeToEdgeMover>();
        _edgeToEdgeMover.enabled = false;
        _mover.enabled = false;
    }
    public void ResetPlayer()
    {
        _edgeToEdgeMover.enabled = true;
        _mover.enabled = true;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        _animator.SetBool("GameOver", false);
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetHero();  
    }
    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
    public void Die()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        _animator.SetBool("GameOver", true);
        GameOver?.Invoke();
        _edgeToEdgeMover.enabled = false;
        _mover.enabled = false;
    }
}
