using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, optionMenu, creditsMenu;
   public void PlayGame()
   {
        SceneManager.LoadScene("Game");
   }

    public void OptionMenu()
    {
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CreditsMenu()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void ReturnMainMenu()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        optionMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
