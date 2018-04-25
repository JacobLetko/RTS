using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour {

    private GameObject current;

	public void SetItem(GameObject b)
    {
        current = Instantiate(b);
    }

    private void Update()
    {
        if(current != null)
        {
            Vector3 m = current.transform.position;
            m.x = Input.mousePosition.x - m.x;
            m.z = Input.mousePosition.z - m.z;
            current.transform.position = m;
        }
    }
}
