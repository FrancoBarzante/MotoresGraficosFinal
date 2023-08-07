using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int defeatedEnemies = 0; 
    public int enemiesToMainMenu = 4; 

    public float timeLimit = 30f; 
    private bool gameIsOver = false;

    private void Start()
    {
        Invoke("CheckForGameover", timeLimit);
    }

    public void CheckForGameover()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            SceneManager.LoadScene("MainMenu"); 
        }
    }

    public void EnemyDefeated()
    {
        defeatedEnemies++;

        if (defeatedEnemies >= enemiesToMainMenu)
        {
            ReturnToMainMenu();
        }
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}

