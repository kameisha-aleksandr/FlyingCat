using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    static public float camWidth;
    static public float camHeight;

    [SerializeField] private Hero _hero;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private FloorBuilder _floorBuilder;
    private HeroTracker _heroTracker;
    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnResrartButtonClick;
        _hero.GameOver += OnGameOver;
    }
    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnResrartButtonClick;
        _hero.GameOver -= OnGameOver;
    }
    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        _heroTracker.StartGame();
        StartGame();
    }
    private void OnResrartButtonClick()
    {
        _gameOverScreen.Close();
        _floorBuilder.ResetBuilder();
        StartGame();
    }

    private void OnGameOver()
    {
        _gameOverScreen.Open();
    }

    private void StartGame()
    {
        _hero.ResetPlayer();
    }
    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
        _floorBuilder = GetComponent<FloorBuilder>();
        _heroTracker = GetComponent<HeroTracker>();
    }

    void Start()
    {
        _startScreen.Open();
    }
}
