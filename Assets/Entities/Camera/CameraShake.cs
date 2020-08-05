using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    float shake = 0f;
    float shakeAmount = 0.2f;
    float decreaseFactor = 1.0f;
    public bool shakeCamera = false;

    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log(shake);
        Debug.Log(shakeCamera);

        if (shakeCamera)
        {
            shake = .2f;
        }

        if (shake > 0f)
        {
            transform.localPosition = Random.insideUnitSphere * shakeAmount + new Vector3(0f, 0f, -10f);
            shake -= Time.deltaTime * decreaseFactor;
            shakeCamera = false;

        }
        else
        {
            shake = 0.0f;
        }
    }
}
