using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;

    }


}
