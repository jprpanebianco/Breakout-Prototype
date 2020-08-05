using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthBasedOnY : MonoBehaviour {

    SpriteRenderer myRenderer;

    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        myRenderer.sortingOrder = (int)Camera.main.WorldToScreenPoint(myRenderer.bounds.min).y * -1;
    }
}
