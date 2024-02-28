using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _gameOverCanvas;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        Time.timeScale = 1f;
    }

    //game over method
    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    //restart method for loading th scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    //menu methods
    public void Play()
    {
        //method for loading the next scene  (choosing a level).
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //method for quitting and closing the game
    public void ExitGame()
    {
        Debug.Log("closing the game....");
        Application.Quit();
    }



    //start level Tierra
    public void StartLevelTierra()
    {
        SceneManager.LoadScene("Level1Tierra");
    }

    //start level Tierra
    public void StartLevelSnow()
    {
        SceneManager.LoadScene("Level2Nieve");
    }

        //start level Monster
    public void StartLevelMoster()
    {
        SceneManager.LoadScene("Level3Monster");
    }

    public void backToLevelSelector()
    {
        SceneManager.LoadScene("Menu");

        
    }

    public void PauseGame()
    {

    }

}
