using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMove : MonoBehaviour
{
    public List<GameObject> units = new List<GameObject>();
    movement move;

    public LayerMask unitLayer;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                for(int i = 0; i < units.Count; i++)
                {
                    move = units[i].GetComponent<movement>();
                    move.setDestination(hit);
                }
            }
        }
        grabUnit();
    }

    private void Start()
    {
        units = new List<GameObject>();
    }

    void grabUnit()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, unitLayer))
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                    units = new List<GameObject>();

                if (!units.Contains(hit.collider.gameObject))
                    units.Add(hit.collider.gameObject);
            }
        }
    }
}
