using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangingSceneButtonController : MonoBehaviour {

    private Button myButton;

    void Start()
    {
        Screen.SetResolution(800,1280,false);
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(MyFunctionForOnClickEvent);
    }

    void MyFunctionForOnClickEvent()
    {
        SceneManager.LoadScene(myButton.name);
    }
}
