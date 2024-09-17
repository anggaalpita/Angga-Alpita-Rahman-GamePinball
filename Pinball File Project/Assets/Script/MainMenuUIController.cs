using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button creditButton; 

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        creditButton.onClick.AddListener(OpenCredits); 
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball Game");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void OpenCredits()
    {
        SceneManager.LoadScene("CreditMenu"); 
    }
}