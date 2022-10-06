using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingFood : MonoBehaviour
{
    public ThirdPersonMovement player;
    public int eatingDuration = 3;

    public ParticleSystem eatingParticle;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoodFood") || other.gameObject.CompareTag("BadFood"))
        {
            Debug.Log(other.gameObject.tag);
            Destroy(other.gameObject);
            StartCoroutine(WaitAndDeleteFood());
            player.soundManager.PlayFoodSound();
            eatingParticle.Play();
        }
    }

    private IEnumerator WaitAndDeleteFood()
    {
        player.animator.SetBool("is_eating", true);
        player.isEating = true;
        Debug.Log("Eating Started");
        
        yield return new WaitForSeconds(eatingDuration);
        Debug.Log("Eating Finished");
        player.animator.SetBool("is_eating", false);
        player.isEating = false;
    }
}
