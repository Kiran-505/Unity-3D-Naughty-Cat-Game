using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingFood : MonoBehaviour
{
    public ThirdPersonMovement player;
    public int eatingDuration = 3;

    public ParticleSystem badFoodParticle;
    public ParticleSystem goodFoodParticle;
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
        string tag = other.gameObject.tag;
        if (tag == "GoodFood" || tag == "BadFood")
        {
            Destroy(other.gameObject);
            StartCoroutine(WaitAndDeleteFood());

            if (tag == "GoodFood")
            {
                player.soundManager.PlayGoodFoodSound();
                goodFoodParticle.Play();
            }
            else
            {
                player.soundManager.PlayBadFoodSound();
                player.gameManager.DecreaseLife();
                badFoodParticle.Play();
            }
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
