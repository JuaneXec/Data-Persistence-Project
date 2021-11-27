using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public string playerName;
    public TMP_InputField inputFieldName;
    public TMP_Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = ("Best Score: " + MenuManager.Instance.playerNameHi + " : " + MenuManager.Instance.scoreHi);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        playerName = inputFieldName.text;
        MenuManager.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
        Debug.Log("You typed: " + playerName);
    }

    public void Exit()
    {
        MenuManager.Instance.SaveName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
