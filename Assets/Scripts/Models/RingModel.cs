using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RingModel : ObjectModel
{
    public int ColorId;
    [SerializeField] Transform[] gfxs;
    [SerializeField] Animator animator;

    public override void Initialize()
    {
        base.Initialize();
        gfxs[ColorId].transform.gameObject.SetActive(true);
    }

    public void OnTake()
    {
        transform.DOMoveY(10f, 0.15f);
    }

    public void OnDrag(Vector3 pos)
    {
        transform.position = new Vector3(pos.x, transform.position.y, pos.z);
    }

    public void OnDrop(Transform targetPos)
    {
        transform.SetParent(targetPos);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        animator.Play("OnPlace", 0, 0);
    }
}