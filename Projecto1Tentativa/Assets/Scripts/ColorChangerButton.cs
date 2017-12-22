using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class ColorChangerButton : MonoBehaviour {

	public Button colorChangerButton;
    public GameObject player;
    public Material[] materials = new Material[4];
    private System.Random random = new System.Random();

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        colorChangerButton = GetComponent<Button>();
		colorChangerButton.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("colorChanger") + "";
        colorChangerButton.onClick.AddListener(() => ColorChangerOnClickEvent());
    }

    void ColorChangerOnClickEvent()
    {
        int colorChangerLeft = PlayerPrefs.GetInt("colorChanger"); 

		if(colorChangerLeft > 0 && !Input.GetKeyDown("space")){

                PlayerPrefs.SetInt("colorChanger", colorChangerLeft - 1);
                colorChangerButton.GetComponentInChildren<Text>().text = (colorChangerLeft -1) + ""; 
                GenerateRandomFourColor();
                GetComponent<AudioSource>().Play();
		}
	}

    void GenerateRandomFourColor()
    {
        Material newMaterial = materials[random.Next(0, materials.Length)];

        while (player.GetComponent<Renderer>().sharedMaterial == newMaterial)
        {
            newMaterial = materials[random.Next(0, materials.Length)];
        }

        player.GetComponent<Renderer>().sharedMaterial = newMaterial;
    }
}
