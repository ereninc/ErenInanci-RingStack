using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingModel : ObjectModel
{
    public int ColorId;
    [SerializeField] Transform[] gfxs;

    public override void Initialize()
    {
        base.Initialize();
        gfxs[ColorId].transform.gameObject.SetActive(true);
    }

    public void OnTake(Vector3 pos) 
    {
        transform.position = pos;
    }

    public void OnDrop(Transform targetPos) 
    {
        transform.SetParent(targetPos); 
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}