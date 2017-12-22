using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButtonController : MonoBehaviour {

    private Button myButton;
    
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(MyFunctionForOnClickEvent);
    }

    void MyFunctionForOnClickEvent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
