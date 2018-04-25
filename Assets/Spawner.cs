using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefab;
    public List<GameObject> pool;
    public int max;
    public int count;

	// Use this for initialization
	void Start ()
    {
		for(int i = 0; i < max; i++)
        {
            GameObject unit =  Instantiate(prefab);
            unit.gameObject.SetActive(false);
            unit.transform.position = transform.position;
            pool.Add(unit);
        }
	}

    public void Spawn()
    {
        if (count < max)
        {
            pool[count].gameObject.SetActive(true);
            count++;
        }
    }
}
