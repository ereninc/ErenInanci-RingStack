using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlaceableAreaModel : ObjectModel
{
    public List<RingModel> PlacedRings;
    [SerializeField] Transform[] ringPositions;
    private int correctCounter;

    public override void Initialize()
    {
        base.Initialize();
        setRings();
    }

    public RingModel GetRing()
    {
        return PlacedRings[PlacedRings.Count - 1];
    }

    public void OnRingPlace(RingModel ring)
    {
        if (PlacedRings.Count < 5)
        {
            PlacedRings.Add(ring);
            ring.OnDrop(ringPositions[PlacedRings.Count - 1]);
        }
    }

    public void OnRingRemove(RingModel ring)
    {
        if (PlacedRings.Count > 0)
        {
            PlacedRings.Remove(ring);
        }
    }

    private void setRings()
    {
        for (int i = 0; i < PlacedRings.Count; i++)
        {
            PlacedRings[i].Initialize();
        }
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