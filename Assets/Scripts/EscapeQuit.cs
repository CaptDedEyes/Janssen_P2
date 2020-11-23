using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeQuit : MonoBehaviour
{
    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/
        
        if(Input.GetKeyDown (KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
