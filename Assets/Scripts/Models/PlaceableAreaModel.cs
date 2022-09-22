using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaceableAreaModel : ObjectModel
{
    public List<RingModel> PlacedRings;
    [SerializeField] Transform[] ringPositions;
    [SerializeField] DummyModel dummyModel;
    [SerializeField] GhostRingModel ghostRingModel;
    private int correctCounter;

    public override void Initialize()
    {
        base.Initialize();
        setRings();
    }

    public void OnRingPlace(RingModel ring)
    {
        if (PlacedRings.Count < 5)
        {
            PlacedRings.Add(ring);
            ring.OnDrop(ringPositions[PlacedRings.Count - 1]);
            dummyModel.SetRinged(true);
        }
    }

    public void OnRingRemove(RingModel ring)
    {
        if (PlacedRings.Count > 0)
        {
            PlacedRings.Remove(ring);
        }
        if (PlacedRings.Count == 0) dummyModel.SetRinged(false);
    }

    public RingModel GetRing()
    {
        return PlacedRings[PlacedRings.Count - 1];
    }

    public bool CheckAreaRings()
    {
        correctCounter = 0;
        for (int i = 0; i < PlacedRings.Count; i++)
        {
            if (i > 0 && (PlacedRings[i].ColorId == PlacedRings[i - 1].ColorId))
            {
                correctCounter++;
                if (i == PlacedRings.Count - 1)
                {
                    if (correctCounter == 3)
                        return true;
                }
            }
        }
        return false;
    }

    public void ShowGhostRing(int colorId)
    {
        if (PlacedRings.Count <= 4) 
            ghostRingModel.Show(ringPositions[PlacedRings.Count], colorId);
    }

    public void HideGhostRing()
    {
        ghostRingModel.Hide();
    }

    private void setRings()
    {
        for (int i = 0; i < PlacedRings.Count; i++)
        {
            PlacedRings[i].Initialize();
        }
    }

    private void onFailMove() 
    {
        
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlaceableAreaModel))]
public class PlaceableAreaModelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("CHECK PLACEABLE AREA"))
        {
            ((PlaceableAreaModel)target).CheckAreaRings();
        }
    }
}
#endif