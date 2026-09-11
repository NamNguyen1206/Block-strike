using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuAnimation : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
}
