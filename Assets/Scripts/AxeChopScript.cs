using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeChopScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public AudioClip[] audioStoneClips;
    

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RandomWoodSound()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }

    public void RandomStoneSound()
    {
        audioSource.clip = audioStoneClips[Random.Range(0, audioStoneClips.Length)];
        audioSource.Play();
    }

    public void StartWoodAnimation()
    {
        animator.enabled = true;
        RandomWoodSound();
        animator.Play("Chop", 0, 0.25f);
    }

    public void StartStoneAnimation()
    {
        animator.enabled = true;
        RandomStoneSound();
        //same animation for now
        animator.Play("Chop", 0, 0.25f);
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
