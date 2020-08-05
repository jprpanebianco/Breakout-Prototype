using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScroll : MonoBehaviour {
    Renderer myRenderer;
    public float speed = 0.02f;

	// Use this for initialization
	void Start () {
        myRenderer = GetComponent<Renderer>();	
    }
	
	// Update is called once per frame
	void Update () {
        myRenderer.material.mainTextureOffset = new Vector2(Time.time * speed, Time.time * speed);
	}
}
