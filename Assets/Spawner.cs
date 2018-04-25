using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefab;
    public List<GameObject> pool;
    public int max;
    public int count;
    public int want;

	// Use this for initialization
	void Start ()
    {
		for(int i = 0; i < max; i++)
        {
            GameObject unit =  Instantiate(prefab, transform);
            unit.gameObject.SetActive(false);
            unit.transform.position = transform.position;
            pool.Add(unit);
        }
	}

    private void Update()
    {
        if (want > 0 && count < max)
        {
            for (int i = 0; i < want; i++)
            {
                StartCoroutine(Spawn());
                count++;
                want--;
            }
        }
    }

    IEnumerator Spawn()
    {
        pool[count].SetActive(true);
        yield return new WaitForSeconds(5);
    }

    public void AddWant()
    {
        want++;
    }
}
