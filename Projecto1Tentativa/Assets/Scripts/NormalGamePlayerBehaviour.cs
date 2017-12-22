using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class NormalGamePlayerBehaviour : MonoBehaviour {

    
    public float jumpForce;
    public Text gameState;
    public Material[] materials = new Material[4];

    private System.Random random = new System.Random();
    private Rigidbody rb;
    private Material currentMaterial;
    private bool currentLevelCompleted;


	void Start () {
        gameState.text = "";
        rb = GetComponent<Rigidbody>();
        GenerateRandomFourColor();
        currentLevelCompleted = false;
	}
	

    void Update()
    {
        try{
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                rb.velocity = Vector3.zero;
                Vector3 jump = new Vector3(0.0f, jumpForce, 0.0f);
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                GetComponent<AudioSource>().Play();
            }
        }catch{

        }
        currentMaterial = gameObject.GetComponent<Renderer>().sharedMaterial;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("StartingPoint"))
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FourColorChanger"))
        {
            GenerateRandomFourColor();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("RedLine") || other.gameObject.CompareTag("BlueLine") || other.gameObject.CompareTag("YellowLine") || other.gameObject.CompareTag("GreenLine"))
        {
            if (other.gameObject.GetComponent<Renderer>().sharedMaterial != currentMaterial)
            {
                Destroy(gameObject);
                gameState.text = "You Lose!";
            }
        }
        else if (other.gameObject.CompareTag("LosingLine"))
        {
                Destroy(gameObject);
                gameState.text = "You Lose!";
        }
        else if (other.gameObject.CompareTag("RedBlueColorChanger"))
        {
            GenerateRandomTwoColor(materials[0].ToString(), materials[2].ToString());
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("RedGreenColorChanger"))
        {
            GenerateRandomTwoColor(materials[0].ToString(), materials[1].ToString());
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("RedYellowColorChanger"))
        {
            GenerateRandomTwoColor(materials[0].ToString(), materials[3].ToString());
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("YellowGreenColorChanger"))
        {
            GenerateRandomTwoColor(materials[3].ToString(), materials[1].ToString());
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("YellowBlueColorChanger"))
        {
            GenerateRandomTwoColor(materials[3].ToString(), materials[2].ToString());
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("BlueGreenColorChanger"))
        {
            GenerateRandomTwoColor(materials[1].ToString(), materials[2].ToString());
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Point"))
        {
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("score", (PlayerPrefs.GetInt("score") + 1));
        }
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            gameState.text = "You Win!";
            currentLevelCompleted = true;
            PlayerPrefs.SetInt("score", (PlayerPrefs.GetInt("score") + 3));
            // isto aqui em baixo não é para acontecer foi só temporário para não o deixar cair e mostrar o "You Lose!" depois de ter ganho
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ |
                RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }

    void GenerateRandomFourColor()
    {
        Material newMaterial = materials[random.Next(0, materials.Length)];
        while (gameObject.GetComponent<Renderer>().sharedMaterial == newMaterial)
        {
            newMaterial = materials[random.Next(0, materials.Length)];
        }
        gameObject.GetComponent<Renderer>().sharedMaterial = newMaterial;
        currentMaterial = gameObject.GetComponent<Renderer>().sharedMaterial;
    }

    void GenerateRandomTwoColor(String color1, String color2)
    {
        Material newMaterial = materials[random.Next(0, materials.Length)];
        while ((newMaterial.ToString() != color1) || (newMaterial.ToString() != color2))
        {
            newMaterial = materials[random.Next(0, materials.Length)];
            if ((newMaterial.ToString().Equals(color1)) || (newMaterial.ToString().Equals(color2)))
            {
                gameObject.GetComponent<Renderer>().sharedMaterial = newMaterial;
                currentMaterial = gameObject.GetComponent<Renderer>().sharedMaterial;
                return;
            }
        }
    }


    public bool GetCurrentLevelCompleted(){
        return currentLevelCompleted;
    }


}