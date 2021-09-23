using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Sprite[] _skins;

    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = _skins[Random.Range(0, _skins.Length)];
    }
}
