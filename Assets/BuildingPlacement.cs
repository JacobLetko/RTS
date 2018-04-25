using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    private BuildingPlaceable place;
    private GameObject current;
    private bool Placed;

    public LayerMask buildings;
    public LayerMask UI;
    private BuildingPlaceable placeOld;

	public void SetItem(GameObject b)
    {
        Placed = false;
        current = Instantiate(b);
        place = current.GetComponent<BuildingPlaceable>();
    }

    bool canPlace()
    {
        if (place.col.Count > 0)
            return false;
        else
            return true;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (current != null && !Placed)
        {
            if(Physics.Raycast(cameraRay, out hit))
            {
                if(hit.collider.tag == "Ground")
                {
                    current.transform.position = hit.point;
                }   
            }
            if (Input.GetMouseButtonDown(0) && canPlace())
                Placed = true;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && canPlace())
            {
                if (Physics.Raycast(cameraRay, out hit, Mathf.Infinity, buildings,QueryTriggerInteraction.Collide))
                {
                    //if (placeOld != null && Physics.Raycast(cameraRay, out hit, Mathf.Infinity, UI))
                    //    placeOld.SetSelected(false);

                    BuildingPlaceable buildingPlaceable = hit.collider.gameObject.GetComponent<BuildingPlaceable>();
                    if(buildingPlaceable != null)
                    {
                        buildingPlaceable.SetSelected(true);
                        placeOld = buildingPlaceable;
                    }

                    //hit.collider.gameObject.GetComponent<BuildingPlaceable>()
                    //placeOld = hit.collider.gameObject.GetComponent<BuildingPlaceable>();
                }
                else
                {
                    placeOld.SetSelected(false);
                    //if (placeOld != null && Physics.Raycast(cameraRay, out hit, Mathf.Infinity, UI))
                        
                }
            }
        }
    }
}
