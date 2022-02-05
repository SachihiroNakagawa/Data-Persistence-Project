using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score \n" +
        GameManager.Instance.playerName1 + " : " + GameManager.Instance.score1 + "\n" +
        GameManager.Instance.playerName2 + " : " + GameManager.Instance.score2 + "\n" +
        GameManager.Instance.playerName3 + " : " + GameManager.Instance.score3;
        nameText.text = GameManager.Instance.playerName; // When player backs from the Main scene.
    }

    public void StartNew()
    {
        GameManager.Instance.playerName = nameText.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        GameManager.Instance.SaveScore(); 
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
