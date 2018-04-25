using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlaceable : MonoBehaviour {

    [HideInInspector]
    public List<Collider> col = new List<Collider>();
    Spawner spawn;

    public GameObject BaseUI;

    private bool selected;

    private void Start()
    {
        SetSelected(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Ground")
            col.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Ground")
            col.Remove(other);
    }

    public void SetSelected(bool s)
    {
        BaseUI.SetActive(s);
        //selected = s;
    }

    private void Update()
    {
        //if (selected)
        //{
        //    BaseUI.SetActive(true);
        //}
        //else
        //    BaseUI.SetActive(false);
    }
}
