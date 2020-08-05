using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceRing : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
        {
            gameObject.SetActive(false);
        }
    }
}
