using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static bool isGamePaused = false;
    private bool isMuted = false;
    private playermovement attackScript;
    private FireBalls fireBalls;
    private void Start()
    {
        AudioListener.pause = isMuted;
        attackScript = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();
        fireBalls = GameObject.FindGameObjectWithTag("Player").GetComponent<FireBalls>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        isMuted = false;
        AudioListener.pause = isMuted;
        attackScript.enabled = true;
        fireBalls.enabled = true;
    }
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        isMuted = true;
        AudioListener.pause = isMuted;
        attackScript.enabled = false;
        fireBalls.enabled = false;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        isMuted = false;
        AudioListener.pause = isMuted;
        attackScript.enabled = true;
        fireBalls.enabled = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
