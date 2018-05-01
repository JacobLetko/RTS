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
    public int count;

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
        count = 0;

        //Pooling
        GameObject hold;
        //base pool
        for (int i =0; i < max; i++)
        {
            hold = Instantiate(Base);
            hold.SetActive(false);
            BasePool[i] = hold;
        }
        //builder pool
        for(int i = 0; i < max; i++)
        {
            hold = Instantiate(Builder);
            hold.SetActive(false);
            BuildersPool[i] = hold;
        }
    }

    public void placeBase()
    {
        BasePool[count].SetActive(true);
         place.SetItem(BasePool[count]);
    }
}
