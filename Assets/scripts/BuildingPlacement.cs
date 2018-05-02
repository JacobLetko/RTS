using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlacement : MonoBehaviour
{
    private BuildingPlaceable place;
    private GameObject current;

    public LayerMask buildings;
    public LayerMask UI;
    private BuildingPlaceable placeOld;

    private bool placed = false;

    public void SetItem(GameObject b)
    {
        placed = false;
        current = b;
        place = current.GetComponent<BuildingPlaceable>();
    }

    bool canPlace()
    {
        return !(place.col.Count > 0);
    }

    private void Update()
    {
        RaycastHit hit;
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (current != null && canPlace() && !placed)
        {
            if (Physics.Raycast(cameraRay, out hit))
            {
                if (hit.collider.tag == "Ground")
                {
                    current.transform.position = hit.point;
                }
            }
            if (Input.GetMouseButtonDown(0) && canPlace())
            {
                current.transform.parent = null;
                placed = true;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && canPlace() && !EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics.Raycast(cameraRay, out hit, Mathf.Infinity, buildings, QueryTriggerInteraction.Collide))
                {
                    BuildingPlaceable buildingPlaceable = hit.collider.gameObject.GetComponent<BuildingPlaceable>();
                    if (buildingPlaceable != null)
                    {
                        buildingPlaceable.SetSelected(true);
                        placeOld = buildingPlaceable;
                    }
                }
                else
                {
                    placeOld.SetSelected(false);
                }
            }
        }
    }
}
