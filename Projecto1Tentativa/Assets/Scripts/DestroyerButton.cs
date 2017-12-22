using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyerButton : MonoBehaviour {

	
	public Button destroyerButton;
    public GameObject shot;
    public Transform shotSpawn;

    void Start()
    {
        destroyerButton = GetComponent<Button>();
		destroyerButton.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("destroyer") + "";
        destroyerButton.onClick.AddListener(() => Destroy());
    }

    void Destroy()
    {
        int destryoerLeft = PlayerPrefs.GetInt("destroyer"); 

		if(destryoerLeft > 0 && !Input.GetKeyDown("space")){

            PlayerPrefs.SetInt("destroyer", destryoerLeft - 1);
            destroyerButton.GetComponentInChildren<Text>().text = (destryoerLeft -1) + "";
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
	}

}
