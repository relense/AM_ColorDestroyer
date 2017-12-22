using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareLeftAndRightBehaviour : MonoBehaviour {
	
	public float addToInitialZ = 20;
 	private Vector3 initialPosition;
 	private Vector3 finalPosition;
 	private float travelingTime = 5f;
	
	void Start () {
		finalPosition = transform.position;
		finalPosition.z = transform.position.z + addToInitialZ;
		initialPosition = transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		 //Vector3.Lerp     -> Interpola entra 2 posições dado um tempo;
		 //Mathf.SmoothStep -> Similar ao Vector3.Lerp mas vai aumentando/diminuindo a velocidade à medida que vai chegando à posição final
		 //Mathf.PingPong   -> Vai alterando o valor do tempo para devolva sempre um valor entre 0 e 1 neste caso
		 //utiliza-se a combinação do SmoothStep com o PingPong para que à medida que o Update vai ser repetidamente executado se obtenha valores diferentes para que a animação ocorra fluidamente
		 transform.position = Vector3.Lerp(initialPosition, finalPosition,  Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time/travelingTime,1f)));
	}
}
