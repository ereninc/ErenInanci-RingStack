using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyModel : ObjectModel
{
    [SerializeField] Animator animator;
    [SerializeField] bool isRinged;

    public void OnComplete()
    {
        if (isRinged)
        {
            animator.Play("DummyJump", 0, 0);
        }
        else
        {
            animator.Play("DummyDance", 0, 0);
        }
    }

    public void SetRinged(bool val)
    {
        isRinged = val;
    }
}