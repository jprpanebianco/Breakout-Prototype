using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {

    public GameObject zombiePrefab;
    public static int roomSize = 5;

    static int numZombies = 10;
    public static GameObject[] allZombies = new GameObject[numZombies];

    public static Vector3 goalPos = Vector3.zero;

	void Start ()
    {
	    for(int i = 0; i < numZombies; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-roomSize, roomSize),
                                      Random.Range(-roomSize, roomSize),
                                      0f);
            allZombies[i] = (GameObject)Instantiate(zombiePrefab, pos, Quaternion.identity);       
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range(0,10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-roomSize, roomSize),
                                  Random.Range(-roomSize, roomSize),
                                  0f);
        }
	}
}
