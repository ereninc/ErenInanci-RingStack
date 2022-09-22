using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : ControllerModel
{
    [SerializeField] DummyModel[] dummies;

    public void OnLevelCompleted() 
    {
        for (int i = 0; i < dummies.Length; i++)
        {
            dummies[i].OnComplete();
        }
    }
}