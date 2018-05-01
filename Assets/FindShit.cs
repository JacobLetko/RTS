using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindShit : MonoBehaviour {

    public BuildingManager[] arr;
	// Use this for initialization
	void Start ()
    {
        arr = FindObjectsOfType<BuildingManager>();
        foreach(BuildingManager t in arr)
        {
            t.transform.parent = transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
