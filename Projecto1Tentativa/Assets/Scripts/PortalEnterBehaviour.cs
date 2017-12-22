using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnterBehaviour : MonoBehaviour {

	public GameObject otherPortal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, otherPortal.transform.position.z);
	}
	void OnCollisionEnter(Collision other) {
		other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, otherPortal.transform.position.z);
	}
}
