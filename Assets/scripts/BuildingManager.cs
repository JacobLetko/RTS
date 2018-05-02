using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {
    [Header("prefabs")]
    public GameObject Base;
    public GameObject Builder;

    public GameObject[] BuildersPool;
    public GameObject[] BasePool;

    public int max;
    public int BaseCount;
    public int BuilderCount;

    private BuildingPlacement place;
    public static BuildingManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else { Destroy(this); }
        BuildersPool = new GameObject[max];
        BasePool = new GameObject[max];

    }

    private void Start()
    {
        place = GetComponent<BuildingPlacement>();
        BaseCount = 0;
        BuilderCount = 0;

        //Pooling
        GameObject hold;
        //base pool
        for (int i =0; i < max; i++)
        {
            hold = Instantiate(Base);
            hold.SetActive(false);
            hold.transform.parent = this.transform;
            BasePool[i] = hold;
        }
        //builder pool
        for(int i = 0; i < max; i++)
        {
            hold = Instantiate(Builder);
            hold.transform.parent = this.transform;
            hold.SetActive(false);
            BuildersPool[i] = hold;
        }
    }

    public void placeBase()
    {
        BasePool[BaseCount].SetActive(true);
        place.SetItem(BasePool[BaseCount]);
        BaseCount++;
    }
}
