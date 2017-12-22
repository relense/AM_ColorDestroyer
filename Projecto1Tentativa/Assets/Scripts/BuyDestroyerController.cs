using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyDestroyerController : MonoBehaviour {

	public Button destroyerButton;
	private static int DESTROYER_PRICE = 5;

    void Start()
    {
		destroyerButton = GetComponent<Button>();
		destroyerButton.GetComponentInChildren<Text>().text = "Destoyer (" + PlayerPrefs.GetInt("destroyer") + ")";
		destroyerButton.onClick.AddListener(DestroyerOnClickEvent);

    }

	void DestroyerOnClickEvent()
    {
        if(PlayerPrefs.GetInt("score") >= DESTROYER_PRICE && PlayerPrefs.HasKey("score")){
			PlayerPrefs.SetInt("score", (PlayerPrefs.GetInt("score") - DESTROYER_PRICE));
			PlayerPrefs.SetInt("destroyer", (PlayerPrefs.GetInt("destroyer") + 1));
			destroyerButton.GetComponentInChildren<Text>().text = "Destoyer (" + PlayerPrefs.GetInt("destroyer") + ")";

		} else {
			return;
		}

    }
}