using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator animator;
    public AnimationClip anim;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public IEnumerator WaitForAnimation()
    {
        if(anim != null)
        {
            float durada = anim.length;
            animator.SetTrigger("animar");
            yield return new WaitForSeconds(durada);
        }
    }
}
