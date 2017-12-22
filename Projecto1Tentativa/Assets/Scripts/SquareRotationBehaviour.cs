using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareRotationBehaviour : MonoBehaviour {

    public float rotationSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationSpeed,0,0);
	}
}
