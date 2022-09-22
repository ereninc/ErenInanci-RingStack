using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : ControllerModel
{
    public static ScreenController Instance;
    [SerializeField] ScreenModel[] screens;

    public override void Initialize()
    {
        base.Initialize();
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    public void ShowScreen(int index) 
    {
        screens[index].Show();
    }
}