using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDepth : MonoBehaviour
{

   TrailRenderer trail;
    // Use this for initialization
    void Start()
    {

        trail = GetComponent<TrailRenderer>();
        trail.sortingLayerName = "Background";
        trail.sortingOrder = 2;
    }
}
