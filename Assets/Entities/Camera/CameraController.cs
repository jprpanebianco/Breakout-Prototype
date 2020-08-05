using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed = 2f;

    GameObject paddle;
    Vector3 des;
    
    // Use this for initialization
	void Start () {
		paddle = GameObject.Find("Paddle");
    }
	
	// Update is called once per frame
	void Update () {
        des = new Vector3(transform.position.x, paddle.transform.position.y / 10, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, des, speed * Time.deltaTime);
    }

}
