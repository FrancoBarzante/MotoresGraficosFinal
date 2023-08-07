using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float rotationSpeed = 100f;
    
    private bool isPaused = false;
    public string mainMenuSceneName = "MainMenu"; 

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        
        rb.velocity = transform.forward * verticalInput * movementSpeed;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

       
    }
    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
       

    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        

    }

   
}
