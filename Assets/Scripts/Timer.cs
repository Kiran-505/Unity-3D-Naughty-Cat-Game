using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    //Timer duration
    [SerializeField]
    private float timerDuration = 1f * 30f;

    //For the diffrent text slots that will display the time
    private float timer;
    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI separator;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;

    private float flashTimer;
    [SerializeField]
    private float flashDuration = 1f; //The full length of the flash

    private void Start()
    {

    }



    void Update()
    {
        if (timer > 0)
        {
            //Continues to countdown and display the time as long as its above 0 minutes left.
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        else
        {
            FlashTimer();
            
        }
    }

    private void UpdateTimerDisplay(float time)
    {
        //rounds value down to make sure that it's really 0 and not 0.1/0.3 etc.
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        //Assigns characters to the string we want to display.
        string currentTime = string.Format("{00:00}{01:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();

    }

    private void FlashTimer() //Checks time and makes sure that once the timer is 0 it flashes instead of continue below 0.
    {
        if (timer != 0)
        {
            timer = 0;
            UpdateTimerDisplay(timer);
        }

        if (timer != timerDuration)
        {
            timer = timerDuration;
            UpdateTimerDisplay(timer);
        }

        if (flashTimer <= 0)
        {
            flashTimer = flashDuration;
        }
        else if (flashTimer <= flashDuration / 2)
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }
        else
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
            Debug.Log("Game over");
        }
    }

    private void SetTextDisplay(bool enabled)
    {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        separator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
    }
}