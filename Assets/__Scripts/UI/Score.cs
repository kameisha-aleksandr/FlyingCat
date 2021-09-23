using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private Text _score;

    private void OnEnable()
    {
        _hero.ScoreChanged += OnScoreChanged;
    }
    private void OnDisable()
    {
        _hero.ScoreChanged -= OnScoreChanged;
    }
    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }

}
