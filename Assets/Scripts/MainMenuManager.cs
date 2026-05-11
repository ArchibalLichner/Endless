using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public void StartGame()
    {
        //goto character select
        SceneManager.LoadScene("CharacterSelect");
    }

    public void Options()
    {
        //show options
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        //exit game
        Application.Quit();
    }

}
