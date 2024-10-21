using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager: MonoBehaviour
{
    [SerializeField]
    private int levelIndex=2;


    public void Play()
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void SetEnglishLanguage()
    {
        Debug.Log($"English");
        LanguageChange.instance.EnglishLanguage();

    }

    public void SetRussianLanguage()
    {
        Debug.Log($"Russian");
        LanguageChange.instance.RussianLanguage();
    }


    public void End()
    {
        SceneManager.LoadScene(0);
    }
}
