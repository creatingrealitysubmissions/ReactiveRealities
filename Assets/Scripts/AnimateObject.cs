using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimateObject : MonoBehaviour
{
    [SerializeField] UnityEvent animationEvent;
    [SerializeField] UnityEvent revertEvent;

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimateSelf()
    {
        if (animator && !animator.GetBool("forward"))
        {
            animator.SetBool("forward", true);
            animator.SetTrigger("animate");
            animationEvent.Invoke();
        }
    }

    public void AnimateChildren()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            AnimateObject animateObject = animator.GetComponent<AnimateObject>();
            if (animateObject)
            {
                animateObject.AnimateSelf();
            }
            else
            {
                animator.SetBool("forward", true);
                animator.SetTrigger("animate");
            }
        }
    }

    public void RevertSelf()
    {
        if (animator && animator.GetBool("forward"))
        {
            animator.SetBool("forward", false);
            animator.SetTrigger("animate");
            revertEvent.Invoke();
        }
    }

    public void RevertChildren()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            AnimateObject animateObject = animator.GetComponent<AnimateObject>();
            if (animateObject)
            {
                animateObject.RevertSelf();
            }
            else
            {
                animator.SetBool("forward", false);
                animator.SetTrigger("animate");
            }
        }
    }

}
