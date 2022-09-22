using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LevelController : ControllerModel
{
    public static LevelController Controller;
    public List<LevelModel> Levels;
    public LevelModel LoadedLevel;

    public override void Initialize()
    {
        base.Initialize();
        LevelModel level = Levels[0];

        if (Controller == null)
        {
            Controller = this;
        }
        else
        {
            Destroy(Controller);
            Controller = this;
        }
        loadLevel();
    }

    private void loadLevel()
    {
        LoadedLevel = Levels[0];
    }

    public void NextLevel()
    {
        //INCREASE LEVEL INDEX
    }

    public void E_SaveLevel()
    {
#if UNITY_EDITOR
        LevelModel level = getActiveLevel();

        var path = EditorUtility.SaveFilePanel("Save Level", "Assets", "", "asset");
        if (path.Length > 0)
        {
            AssetDatabase.CreateAsset(level, path.Remove(0, path.IndexOf("Assets")));
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        LoadedLevel = null;
#endif
    }

    private LevelModel getActiveLevel()
    {
        LevelModel levelData = ScriptableObject.CreateInstance<LevelModel>();
        //AreaModel[] areas = FindObjectsOfType<AreaModel>();
        //levelData.AreaDatas = new AreaDataModel[areas.Length];
        //for (int i = 0; i < areas.Length; i++)
        //{
            //levelData.AreaDatas[i] = areas[i].GetDataModel();
        //    areas[i].SetDeactive();
        //}
        return levelData;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(LevelController))]
public class LevelControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Create Level"))
        {
            ((LevelController)target).E_SaveLevel();
        }
    }
}
#endif