using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    public void activarAnimacion()
    {
        int x = 0;
        if (animator != null)
        {
            animator.SetBool("open", true);
        }
    }
}
