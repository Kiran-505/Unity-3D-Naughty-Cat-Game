using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource playerAudio;

    public AudioClip jumpSound;
    public AudioClip goodFoodSound;
    public AudioClip badFoodSound;

    public float soundVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSound()
    {
        playerAudio.PlayOneShot(jumpSound, soundVolume);
    }

    public void PlayGoodFoodSound()
    {
        playerAudio.PlayOneShot(goodFoodSound, soundVolume);
    }

    public void PlayBadFoodSound()
    {
        playerAudio.PlayOneShot(badFoodSound, soundVolume);
    }
}
