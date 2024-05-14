using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenManager : MonoBehaviour
{
    public GameObject endPanel;

    private GameObject[] playersFeedback;

    public void PlayAgain()
    {
        endPanel.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScreen");
    }

    public void StopGame()
    {
        Application.Quit();
    }

    public void ShowEndPanel()
    {
        endPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowEndPanel();
    }
}
