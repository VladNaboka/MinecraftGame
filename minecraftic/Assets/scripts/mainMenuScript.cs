using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuScript : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button optionsCloseButton;
    public Button exitButton;
    public GameObject optionsPanel;

    public void Start()
    {
        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(OpenOptionsPanel);
        exitButton.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
    public void CloseOptionsPanel() {
        optionsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
