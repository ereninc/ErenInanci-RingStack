using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : ControllerModel
{
    public static GameStateController Instance;
    public static GameStates CurrentState;

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
        ChangeState(GameStates.Game);
    }

    public void ChangeState(GameStates state)
    {
        CurrentState = state;
    }
}