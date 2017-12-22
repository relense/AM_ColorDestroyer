using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	public GameObject explosion;

    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
		rb.velocity = transform.up * speed;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("RedLine") || other.gameObject.CompareTag("BlueLine") 
		|| other.gameObject.CompareTag("YellowLine") || other.gameObject.CompareTag("GreenLine") 
		|| other.gameObject.CompareTag("LosingLine")){

			Instantiate(explosion, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), other.transform.rotation);

            Destroy(other.gameObject);
			Destroy(gameObject);
        }
	}
		
}
