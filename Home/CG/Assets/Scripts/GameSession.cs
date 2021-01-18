using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;

    // Runs before Start()
    void Awake()
    {
        SetUpSingleton();
    }

    // Make sure only 1 GameSession is running
    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;

        if (score >= 100)
        {
            FindObjectOfType<Levels>().LoadWinner();
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
