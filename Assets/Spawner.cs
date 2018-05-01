using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int want;
    public GameObject GameManager;
    BuildingManager manager;

	// Use this for initialization
	void Start ()
    {
        manager = GameManager.GetComponent<BuildingManager>();
        manager = BuildingManager.instance;
	}

    private void Update()
    {
        if (want > 0 && manager.count< manager.max)
        {
            for (int i = 0; i < want; i++)
            {
                StartCoroutine(Spawn());
                want--;
            }
        }
    }

    IEnumerator Spawn()
    {
        manager.BuildersPool[manager.count].SetActive(true);
        manager.count++;
        //manager.findObject();
        yield return new WaitForSeconds(5);
    }

    public void AddWant()
    {
        want++;
    }
}
