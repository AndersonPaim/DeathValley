using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Mapa1");
    }
    public void voltarMenu()
    {
        SceneManager.LoadScene("Home");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
  
}
