using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireTrap : MonoBehaviour
{
    private GameObject platformPart;
    private Collider2D firePart;
    private Animator animator;
    private float animationLength;
    private bool endOfCoroutine = true;
    

    const string fireTrapIdle = "Fire Trap Idle";
    const string fireTrapClick = "Fire Trap Click";
    const string fireTrapBurning = "FIre Trap Burning";
    private float clickTimeAnimation, burningTimeAnimation;

    private void Awake()
    {
        platformPart = transform.GetChild(0).gameObject;
        firePart = transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        animator = platformPart.GetComponent<Animator>();
    }
    void Start()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            if(clip.name == fireTrapClick)
            {
                clickTimeAnimation = clip.length;

            }else if(clip.name == fireTrapBurning)
            {
                burningTimeAnimation = clip.length;
            }
        }
        
    }


   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && endOfCoroutine)
        {
            StartCoroutine(FireTrapClick());
            endOfCoroutine = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Burn MF!!");
        }
    }

   IEnumerator FireTrapClick()
    {
        animator.Play(fireTrapClick);
        
        yield return new WaitForSeconds(clickTimeAnimation);
        firePart.enabled = true;
        animator.Play(fireTrapBurning);
        
        yield return new WaitForSeconds(burningTimeAnimation*10f);
        animator.Play(fireTrapIdle);
        endOfCoroutine = true;
        firePart.enabled = false;

        yield return null;
        
    }
}
