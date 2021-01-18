using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    [SerializeField] float delaySeconds1 = 1f;
    [SerializeField] float delaySeconds2 = 2f;
    // Health health;    

    IEnumerator WaitAndLoadGameOver()
    {
        yield return new WaitForSeconds(delaySeconds2);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator WaitAndLoadWinner()
    {
        yield return new WaitForSeconds(delaySeconds1);
        SceneManager.LoadScene("Winner");
    }

    public void LoadStartMenu()
    {
        // Load first scene in project
        SceneManager.LoadScene("Menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("CG");

        if (!FindObjectOfType<GameSession>())
        {
            return;
        }

        // Reset GameSession
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoadGameOver());
    }

    public void LoadWinner()
    {
        StartCoroutine(WaitAndLoadWinner());        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
