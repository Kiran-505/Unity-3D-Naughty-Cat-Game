using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image livesImage;
    public Sprite[] livesSprites;

    public GameObject gameOverObject;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Set the lives image to the number of lives that are remaining
    public void SetLivesImage(int lives)
    {
        if (lives <= 0)
        {
            Destroy(livesImage.gameObject);
        }
        else
        {
            livesImage.sprite = livesSprites[lives - 1];
        }
    }

    // Show the gameover image when the game is over
    public void ShowGameOverScreen()
    {
        gameOverObject.SetActive(true);
    }

    // Set the current score as text when it gets updated
    public void SetScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
  