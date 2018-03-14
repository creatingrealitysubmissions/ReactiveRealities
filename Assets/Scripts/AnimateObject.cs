using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateObject : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimateSelf()
    {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.SetTrigger("animate");
        }
    }

    public void AnimateChildren()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            animator.SetTrigger("animate");
        }
    }

}
