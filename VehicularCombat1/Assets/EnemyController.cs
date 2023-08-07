using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3; 
    private int currentHealth; 

    private static int defeatedEnemies = 0; 
    public int enemiesToMainMenu = 4; 

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Defeated();
        }
    }

    private void Defeated()
    {
        defeatedEnemies++;

        if (defeatedEnemies >= enemiesToMainMenu)
        {
            ReturnToMainMenu();
        }

        Destroy(gameObject);

        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.EnemyDefeated();
        }

        Destroy(gameObject);
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    
}
