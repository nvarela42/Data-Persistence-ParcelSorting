using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]
public class UIMenu : MonoBehaviour
{

    public TextMeshProUGUI inputField;
    public TextMeshProUGUI errorMessage;
    public TextMeshProUGUI savePlayerText;
    public TextMeshProUGUI saveScoreText;
    public TextMeshProUGUI currentPlayerNameText;
    public TextMeshProUGUI currentPlayerScoreText;
    public TextMeshProUGUI currentPlayerBloc;

    private void Start()
    {
        if (MainManager.instance.isNotStartApp)
        {
            MainManager.instance.LoadData();
            currentPlayerBloc.gameObject.SetActive(true);
            currentPlayerNameText.text = MainManager.instance.currentPlayerName;
            currentPlayerScoreText.text = MainManager.instance.currentScore.ToString();
        }
        savePlayerText.text = MainManager.instance.savePlayer;
        saveScoreText.text = MainManager.instance.saveScore.ToString();
    }

    private void StartNew()
    {
        ReadPlayerNameInput();
        if (MainManager.instance.currentPlayerName.Length > 1)
        {
            errorMessage.gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }
        errorMessage.gameObject.SetActive(true);
        errorMessage.text = "Please enter your player name, minimum 2 character";
    }

    public void ReadPlayerNameInput()
    {
        MainManager.instance.currentPlayerName = inputField.text;
        Debug.Log("in Read Player Name, mainManger :" + MainManager.instance.currentPlayerName);
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
