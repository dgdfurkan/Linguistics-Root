using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, optionMenu, creditsMenu;
    public AudioSource clickSound;
   public void PlayGame()
   {
        clickSound.Play();
        SceneManager.LoadScene("Game");
   }

    public void OptionMenu()
    {
        clickSound.Play();
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CreditsMenu()
    {
        clickSound.Play();
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void ReturnMainMenu()
    {
        clickSound.Play();
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        optionMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
