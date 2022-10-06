using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int MaximumLives = 3;
    private int currentLives;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
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
        else
        {
            currentLives--;
        }
    }

    public bool GameOver()
    {
        return gameOver;
    }

}
