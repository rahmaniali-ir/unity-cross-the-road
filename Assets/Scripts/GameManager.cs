using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool walking = false;
    [SerializeField] GameObject player;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject levelCompleted;
    [SerializeField] TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        scoreText.text = "Score " + SceneManager.GetActiveScene().buildIndex.ToString();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        player.GetComponent<PlayerMovement>().DeactivatePlayer();
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        player.GetComponent<PlayerMovement>().ActivatePlayer();
    }

    public void StartGame()
    {
        ResumeGame();
        menu.SetActive(false);
    }

    public void GameOver()
    {
        PauseGame();
        gameOver.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void IncreaseScore()
    {
        scoreText.text = "Score: " + (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        player.GetComponent<PlayerMovement>().ActivatePlayer();
    }

    public void LevelCompleted()
    {
        IncreaseScore();
        PauseGame();
        levelCompleted.SetActive(true);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ResumeGame();
    }
}
