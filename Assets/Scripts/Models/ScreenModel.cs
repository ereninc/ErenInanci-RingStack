using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenModel : ObjectModel
{
    [SerializeField] Animator animator;

    public void Show()
    {
        SetActivate();
        animator.Play("Intro");
    }

    public void Hide() 
    {
        animator.Play("Outro");
    }

    public void OnNextLevel() 
    {
        SceneManager.LoadScene(0);
    }
}