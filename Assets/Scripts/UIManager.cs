using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image livesImage;
    public Sprite[] livesSprites;

    public GameObject gameOverObject;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLivesImage(int lives)
    {
        Debug.Log("Lives: " + lives);
        if (lives <= 0)
        {
            Destroy(livesImage.gameObject);
        }
        else
        {
            livesImage.sprite = livesSprites[lives - 1];
        }
    }

    public void ShowGameOverScreen()
    {
        gameOverObject.SetActive(true);
    }
}
  