using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        print("ออกไป ไอเปรต");
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
