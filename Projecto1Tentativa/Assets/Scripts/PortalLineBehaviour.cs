using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLineBehaviour : MonoBehaviour {

	public float lineSpeed = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float translation = lineSpeed * Time.deltaTime;
		transform.Translate(0, 0, translation);
	}
}
