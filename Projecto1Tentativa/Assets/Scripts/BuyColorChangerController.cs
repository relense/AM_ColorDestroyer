using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyColorChangerController : MonoBehaviour {

	public Button colorChangerButton;
    private static int COLOR_CHANGER_PRICE = 2;

    void Start()
    {
        colorChangerButton = GetComponent<Button>();
        colorChangerButton.GetComponentInChildren<Text>().text = " Color Changer (" + PlayerPrefs.GetInt("colorChanger") + ")";
        colorChangerButton.onClick.AddListener(ColorChangerOnClickEvent);

    }

    void ColorChangerOnClickEvent()
    {
        if(PlayerPrefs.GetInt("score") >= COLOR_CHANGER_PRICE && PlayerPrefs.HasKey("score")){
			PlayerPrefs.SetInt("score", (PlayerPrefs.GetInt("score") - COLOR_CHANGER_PRICE));
			PlayerPrefs.SetInt("colorChanger", (PlayerPrefs.GetInt("colorChanger") + 1));
            colorChangerButton.GetComponentInChildren<Text>().text = "Color Changer (" + PlayerPrefs.GetInt("colorChanger") + ")";

		} else {
			return;
		}

    }
}
