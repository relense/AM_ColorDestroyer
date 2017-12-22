using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButtonController : MonoBehaviour {


	public GameObject player;
	private Button myButton;
	private NormalGamePlayerBehaviour playerScript;
	private BouncingGamePlayerBehaviour playerScript2;


	// Use this for initialization
	void Start () {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(MyFunctionForOnClickEvent);
		if(SceneManager.GetActiveScene().name.Substring(0,19).Equals("NormalGameModeLevel")){
			playerScript = player.GetComponent<NormalGamePlayerBehaviour>();
		}else if(SceneManager.GetActiveScene().name.Substring(0,21).Equals("BouncingGameModeLevel")){
			playerScript2 = player.GetComponent<BouncingGamePlayerBehaviour>();
		}
		myButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name.Substring(0,19).Equals("NormalGameModeLevel")){
			if(playerScript.GetCurrentLevelCompleted()){
				myButton.interactable = true;
			}
		}else if(SceneManager.GetActiveScene().name.Substring(0,21).Equals("BouncingGameModeLevel")){
			if(playerScript2.GetCurrentLevelCompleted()){
				myButton.interactable = true;
			}
		}
	}

	void MyFunctionForOnClickEvent()
    {
        SceneManager.LoadScene(myButton.name);
    }
}
