using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMove : MonoBehaviour
{
    public List<GameObject> units = new List<GameObject>();
    movement Move;

    private Vector3 startpos = Vector3.zero;
    private Vector3 endpos = Vector3.zero;
    private Vector3 extents;
    private Vector3 boxPos;
    public LayerMask unitLayer;
    private Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
        extents = Vector3.one;
        boxPos = transform.position;
        units = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        grabUnit();
    }

    void move()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                for (int i = 0; i < units.Count; i++)
                {
                    Move = units[i].GetComponent<movement>();
                    Move.setDestination(hit);
                }
            }
        }
    }
    void grabUnit()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, unitLayer))
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                    units = new List<GameObject>();

                if (!units.Contains(hit.collider.gameObject))
                    units.Add(hit.collider.gameObject);
            }
        }
        //else if(Input.GetMouseButtonDown(0))
        //{
        //    if(startpos != Vector3.zero)
        //        startpos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //    boxOverlay();
        //}
        //else
        //{
        //    startpos = Vector3.zero;
        //    endpos = Vector3.zero;
        //}


        if(Input.GetMouseButtonDown(0))
        {
            startpos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.farClipPlane));
        }
        if(Input.GetMouseButtonUp(0))
        {
            boxOverlay();
        }

    }

    void boxOverlay()
    {
        endpos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.farClipPlane));
        extents.x = startpos.x - endpos.x;
        extents.z = startpos.z - endpos.z;
        boxPos = endpos + (extents / 2);



        Collider[] hitColliders = Physics.OverlapBox(boxPos, extents / 2, Quaternion.identity, unitLayer);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            //Output all of the collider names
            Debug.Log("Hit : " + hitColliders[i].name + i);
            //add to list
            units.Add(hitColliders[i].gameObject);
            //Increase the number of Colliders in the array
            i++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
        Gizmos.DrawWireCube(boxPos, extents);
    }
}
