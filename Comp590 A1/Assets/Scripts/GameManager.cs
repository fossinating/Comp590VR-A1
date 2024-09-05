using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int highscore = 0;
    public int playerHealth = 3;
    public int score = 0;
    public bool playing = false;

    [SerializeField] Text startHighScoreLabel;
    [SerializeField] Text deathHighScoreLabel;
    [SerializeField] Text deathScoreLabel;

    [SerializeField] Text statusLabel;

    [SerializeField] Canvas startScreen;
    [SerializeField] Canvas deathScreen;

    [SerializeField] public SphericEnemy enemyPrefab;
    private float timeLeft;
    private float waitTime = 30f;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
            startHighScoreLabel.text = "High Score: " + highscore.ToString();
        }
        UpdateStatus();
    }

    void UpdateStatus() {
        statusLabel.text = "Score: " + score.ToString() + "\n" + new StringBuilder().Insert(0, "❤️", playerHealth).ToString();
    }


    void StartGame()
    {
        playerHealth = 3;
        score = 0;
        playing = true;
        foreach (SphericEnemy e in transform.parent.GetComponentsInChildren<SphericEnemy>())
        {
            e.Kill();
        }
        UpdateStatus();
        statusLabel.enabled = true;
    }

    public void DamagePlayer()
    {
        playerHealth -= 1;
        UpdateStatus();
        if (playerHealth <= 0) {
            GameOver();
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateStatus();
    }

    void GameOver()
    {
        playing = false;
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.Save();
        }

        statusLabel.enabled = false;
        deathScreen.enabled = true;
        deathHighScoreLabel.text = "High Score: " + highscore.ToString();
        deathScoreLabel.text = "Score: " + score.ToString();

        foreach (SphericEnemy e in transform.parent.GetComponentsInChildren<SphericEnemy>())
        {
            e.Stop();
        }
    }

    void FixedUpdate()
    {
        if (playing)
        {
            timeLeft -= Time.fixedDeltaTime;
            if (timeLeft < 0)
            {
                SphericEnemy enemy = Instantiate(enemyPrefab);
                waitTime = Mathf.Max(1f, waitTime - .3f);
                timeLeft = waitTime;
            }
        } else
        {
            // Source: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.10/api/UnityEngine.InputSystem.EnhancedTouch.Touch.html
            foreach (var touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
            {
                if (touch.began)
                {
                    StartGame();
                    break;
                }
            }
        }
    }
}
