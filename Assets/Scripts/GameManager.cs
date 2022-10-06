using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int MaximumLives = 3;
    public int GoodFoodCount = 10;
    private int currentLives;
    private int currentGoodFoodCount;
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

    // Resets all the variables
    public void ResetGame()
    {
        currentLives = MaximumLives;
        currentGoodFoodCount = 0;
        gameOver = false;
    }

    // Decreases life when cat eats bad food
    public void DecreaseLife()
    {
        if (currentLives == 1)
        {
            gameOver = true;
        }
        currentLives--;
        uiManager.SetLivesImage(currentLives);
    }

    // Returns if game is over or not
    public bool GameOver()
    {
        return gameOver;
    }

    public void SetGameOver(bool over)
    {
        gameOver = over;
    }

    // Returns number of remaining lives
    public int RemainingLives()
    {
        return currentLives;
    }

    // Show the gameover screen using UI manager
    public void ShowGameOverScreen()
    {
        uiManager.ShowGameOverScreen();
    }

    // Increment good food count and update the score
    public void AddCurrentGoodFood()
    {
        currentGoodFoodCount++;
        if (currentGoodFoodCount == GoodFoodCount)
        {
            gameOver = true;
        }
        uiManager.SetScore(currentGoodFoodCount);
    }
}
