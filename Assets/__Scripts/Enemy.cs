using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Sprite[] _skins;

    protected SpriteRenderer _spriteRenderer;
    protected float _enemyWidth;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _skins[Random.Range(0, _skins.Length)];
        _enemyWidth = _spriteRenderer.sprite.bounds.size.x * transform.localScale.x;
    }
}
