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
        if (want > 0 && manager.BuilderCount< manager.max)
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
        yield return new WaitForSeconds(5);
        manager.BuildersPool[manager.BuilderCount].SetActive(true);
        manager.BuildersPool[manager.BuilderCount].transform.parent = null;
        manager.BuildersPool[manager.BuilderCount].transform.position = this.transform.position;
        manager.BuilderCount++;
    }

    public void AddWant()
    {
        want++;
    }
}
