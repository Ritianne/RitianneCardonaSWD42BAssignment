using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    [SerializeField] float delaySeconds = 2f;
    // Health health;    

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadStartMenu()
    {
        // Load first scene in project
        SceneManager.LoadScene("Menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("CG");
        // Reset GameSession
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadWinner()
    {        
        SceneManager.LoadScene("Winner");        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
