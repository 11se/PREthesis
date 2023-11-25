using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject HEALTHUI;
    public GameObject BLOODLUSTUI;
    public GameObject HEALTHICONUI;
    public GameObject BLOODLUSTICONUI;
    public GameObject CROSSHAIRNUI;
    public GameObject GUNUI;   
    public GameObject AMMOUI;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        HEALTHUI.SetActive(true);
        BLOODLUSTUI.SetActive(true);
        HEALTHICONUI.SetActive(true);
        BLOODLUSTICONUI.SetActive(true);
        CROSSHAIRNUI.SetActive(true);
        GUNUI.SetActive(true);      
        AMMOUI.SetActive(true);
        Time.timeScale = 1;
        IsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        HEALTHUI.SetActive(false);
        BLOODLUSTUI.SetActive(false);
        HEALTHICONUI.SetActive(false);
        BLOODLUSTICONUI.SetActive(false);
        CROSSHAIRNUI.SetActive(false);
        GUNUI.SetActive(false);    
        AMMOUI.SetActive(false);
        Time.timeScale = 0;
        IsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
