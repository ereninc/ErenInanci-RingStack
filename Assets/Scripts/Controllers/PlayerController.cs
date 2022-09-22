using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ControllerModel
{
    [SerializeField] PlaceableAreaModel placeableArea;
    [SerializeField] PlaceableAreaModel targetPlaceableArea;
    [SerializeField] RingModel selectedRing;

    private RaycastHit hit;
    private Ray ray;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void ControllerUpdate()
    {
        base.ControllerUpdate();
        if (GameStateController.CurrentState == GameStates.Game)
        {
            moveRings();
        }
    }

    private void moveRings()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (placeableArea = hit.transform.GetComponent<PlaceableAreaModel>())
                {
                    if (placeableArea.PlacedRings.Count > 0)
                    {
                        selectedRing = placeableArea.GetRing();
                        selectedRing.OnTake();
                        placeableArea.OnRingRemove(selectedRing);
                    }
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (selectedRing != null)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (targetPlaceableArea = hit.transform.GetComponent<PlaceableAreaModel>())
                    {
                        targetPlaceableArea.ShowGhostRing(selectedRing.ColorId);
                    }
                    selectedRing.OnDrag(hit.point);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (targetPlaceableArea == null && selectedRing != null)
                {
                    placeableArea.OnRingPlace(selectedRing);
                    placeableArea.HideGhostRing();
                    AreaController.Instance.CheckMoves();
                }

                if (targetPlaceableArea = hit.transform.GetComponent<PlaceableAreaModel>())
                {
                    placeableArea.OnRingRemove(selectedRing);
                    if (targetPlaceableArea.PlacedRings.Count >= 5)
                    {
                        placeableArea.OnRingPlace(selectedRing);
                    }
                    else
                    {
                        targetPlaceableArea.OnRingPlace(selectedRing);
                    }
                    AreaController.Instance.CheckMoves();
                    targetPlaceableArea.HideGhostRing();
                    targetPlaceableArea = null;
                }
            }
            placeableArea = null;
            selectedRing = null;
        }
    }
}
