using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieKiller : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Zombie")
        {
            collider.gameObject.SetActive(false);
        }
    }
}
