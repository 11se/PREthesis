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
    public GameObject WAYPOINTUI;
    public GameObject OBJECTIVE1;
    public GameObject OBJECTIVE2;
    public GameObject NEWOBJECTIVE1;
    public GameObject NEWOBJECTIVE2;


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
        WAYPOINTUI.SetActive(true);
        OBJECTIVE1.SetActive(true);
        OBJECTIVE2.SetActive(true);

        NEWOBJECTIVE1.SetActive(false);
        NEWOBJECTIVE2.SetActive(false);
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
        WAYPOINTUI.SetActive(false);
        OBJECTIVE1.SetActive(false);
        OBJECTIVE2.SetActive(false);

        NEWOBJECTIVE1.SetActive(true);
        NEWOBJECTIVE2.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
