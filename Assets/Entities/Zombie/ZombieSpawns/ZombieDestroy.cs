using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDestroy : MonoBehaviour {

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

}
