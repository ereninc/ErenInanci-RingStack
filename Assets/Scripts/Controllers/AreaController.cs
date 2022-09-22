using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AreaController : ObjectModel
{
    public static AreaController Instance;
    [SerializeField] List<PlaceableAreaModel> areas;
    [SerializeField] DummyController dummyController;
    private int completedAreaCount;

    public override void Initialize()
    {
        base.Initialize();
        setAreas();
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    private void setAreas()
    {
        for (int i = 0; i < areas.Count; i++)
        {
            areas[i].Initialize();
        }
    }

    public void CheckMoves()
    {
        completedAreaCount = 0;
        for (int i = 0; i < areas.Count; i++)
        {
            if (areas[i].CheckAreaRings())
            {
                completedAreaCount++;
                if (completedAreaCount == areas.Count - 1)
                {
                    ScreenController.Instance.ShowScreen(0);
                    GameStateController.Instance.ChangeState(GameStates.End);
                    dummyController.OnLevelCompleted();
                }
            }
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(AreaController))]
public class AreaControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("CHECK MOVES"))
        {
            ((AreaController)target).CheckMoves();
        }
    }
}
#endif