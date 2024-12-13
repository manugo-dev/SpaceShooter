using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;  
    [SerializeField] private int startingLives = 3; 

    private int score = 0;  
    private int lives;     

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;
        lives = startingLives;

        UpdateScoreUI();
        UpdateLivesUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }
    public void RemoveLife()
    {
        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }
    public void AddLife()
    {
        lives++;
        UpdateLivesUI();
    }

    public void ResetGame()
    {
        score = 0;
        lives = startingLives;

        UpdateScoreUI();
        UpdateLivesUI();
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
}
