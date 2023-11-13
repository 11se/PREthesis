using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    
    public void DeadMenuButton(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
    public void quitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        
    }
}
