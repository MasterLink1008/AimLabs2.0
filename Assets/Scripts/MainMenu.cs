using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool MultiShot = false;
    public static bool Classic = false;
    public static bool Tracker = false;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Has Quit");
    }

    public void MultiShotSelection()
    {
        MultiShot = true;
    }

    public void ClassicSelection()
    {
        Classic = true;
    }
    public void TrackerSelection()
    {
        Tracker = true;
    }
}
