using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRingModel : ObjectModel
{
    [SerializeField] Transform[] ringGfxs;

    public void Show(Transform point, int colorId) 
    {
        SetActivate();
        transform.position = point.position;
        closeRings();
        ringGfxs[colorId].gameObject.SetActive(true);
    }

    public void Hide()
    {
        closeRings();
        SetDeactive();
    }

    private void closeRings()
    {
        for (int i = 0; i < ringGfxs.Length; i++)
        {
            ringGfxs[i].gameObject.SetActive(false);
        }
    }
}