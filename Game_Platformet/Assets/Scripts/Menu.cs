using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void goToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void GoToScene(string scene)
    {
        goToScene(scene);
    }
    
    public void GameQuit()
    {
        Application.Quit();
    }
}
