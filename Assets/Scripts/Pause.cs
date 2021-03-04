using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static bool pausado = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (pausado)
            {
                resume();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pause();
                Cursor.lockState = CursorLockMode.None;
            }
            
        }
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }


    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
