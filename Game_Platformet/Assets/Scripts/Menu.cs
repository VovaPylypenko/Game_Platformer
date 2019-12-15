using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string orderPlayerScene;
    
    private void goToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void GoToOrderPlayerScene()
    {
        goToScene(orderPlayerScene);
    }
    
    public void GoToArenaMappingScene(string scene)
    {
        goToScene(scene);
    }
    
    public void GameQuit()
    {
        Application.Quit();
    }
}
