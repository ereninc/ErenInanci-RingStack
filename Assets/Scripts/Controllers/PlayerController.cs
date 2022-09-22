using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ControllerModel
{
    [SerializeField] PlaceableAreaModel placeableArea;
    [SerializeField] PlaceableAreaModel targetPlaceableArea;
    [SerializeField] RingModel selectedRing;
    RaycastHit hit;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void ControllerUpdate()
    {
        base.ControllerUpdate();
        getMouseInput();
    }

    private void getMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (placeableArea = hit.transform.GetComponent<PlaceableAreaModel>())
                {
                    if (placeableArea.PlacedRings.Count > 0)
                    {
                        //Debug.Log("THERE ARE RINGS");
                        selectedRing = placeableArea.GetRing();
                    }
                    else
                    {
                        //Debug.Log("THERE ARE NO RINGS");
                    }
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (selectedRing != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (targetPlaceableArea = hit.transform.GetComponent<PlaceableAreaModel>())
                    selectedRing.OnTake(hit.point);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (targetPlaceableArea != null)
            {
                targetPlaceableArea.OnRingPlace(selectedRing);
                placeableArea.OnRingRemove(selectedRing);
                AreaController.Instance.CheckMoves();
            }
            targetPlaceableArea = null;
            placeableArea = null;
            selectedRing = null;
        }
    }
}
