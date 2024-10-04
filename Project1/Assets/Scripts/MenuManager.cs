using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager: MonoBehaviour
{
    public int levelIndex=1;

    public void Play()
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
