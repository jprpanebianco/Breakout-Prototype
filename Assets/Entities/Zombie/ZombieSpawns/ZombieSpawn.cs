using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour {

    public float spawnTime = 2f;

	void Start () {
    
        InvokeRepeating("AriseZombie", spawnTime, spawnTime);
	}
	
	public void AriseZombie () {

        GameObject obj = ObjectPooler.current.GetPooledObject();

        obj.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y);
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
        
	}
}
