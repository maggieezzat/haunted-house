using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void StartGame()
    {
        
        SceneManager.LoadScene("RoomSelection");

    }

    public void QuitApplication()
    {
        Application.Quit();

    }

    public void loadZombieScene()
    {
        SceneManager.LoadScene("ZombieScene");

    }

    public void loadWizardScene()
    {
        SceneManager.LoadScene("VampireScene");

    }

    public void backToMain()
    {
        SceneManager.LoadScene("MainMenu");

    }



    
}
