using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject inventoryUI;
    public GameObject gameOverUI;

    [Header("Player Settings")]
    public PlayerBehaviour player;
    public HealthBarScreenSpaceController healthBar;

    [Header("Scene Data")]
    public SceneDataSO sceneData;

    private void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{       
        //if (GameIsPaused)
        //{
        //    Resume();
        //}
        //else
        //{
        //    Pause();
        //} 
        //}     
        if (player.health <= 0)
        {
            gameOverUI.SetActive(true);
        }
    }

    void TogglePauseMenu()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Save()
    {
        sceneData.playerPosition = player.transform.position;
        sceneData.playerRotation = player.transform.rotation;
        sceneData.playerHealth = player.health;
    }

    public void Load()
    {
        player.controller.enabled = false;
        player.transform.position = sceneData.playerPosition;
        player.transform.rotation = sceneData.playerRotation;
        player.controller.enabled = true;

        player.health = sceneData.playerHealth;
        player.healthBar.SetHealth(sceneData.playerHealth);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void OnPauseMenuButtonPressed()
    {
        TogglePauseMenu();
    }

    public void ToggleInventoryUI()
    {
        inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
    }
}        
