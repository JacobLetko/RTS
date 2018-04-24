using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefab;
    public List<GameObject> pool;
    public float spawnRate;
    float timer;
    public int count = 0;
    public int max;

	// Use this for initialization
	void Start ()
    {
        timer = spawnRate;
		for(int i = 0; i < max; i++)
        {
            GameObject unit =  Instantiate(prefab);
            unit.gameObject.SetActive(false);
            unit.transform.position = transform.position;
            pool.Add(unit);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            Spawn();
            timer = spawnRate;
        }
    }

    private void Spawn()
    {
        if (count < max)
        {
            pool[count].gameObject.SetActive(true);
            count++;
        }
    }
}
