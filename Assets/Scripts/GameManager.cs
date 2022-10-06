using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int MaximumLives = 3;
    private int currentLives;
    private bool gameOver = false;

    private UIManager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        currentLives = MaximumLives;
        gameOver = false;
    }

    public void DecreaseLife()
    {
        if (currentLives == 1)
        {
            gameOver = true;
        }
        currentLives--;
        uiManager.SetLivesImage(currentLives);
    }

    public bool GameOver()
    {
        return gameOver;
    }

    public int RemainingLives()
    {
        return currentLives;
    }

    public void ShowGameOverScreen()
    {
        uiManager.ShowGameOverScreen();
    }
}
