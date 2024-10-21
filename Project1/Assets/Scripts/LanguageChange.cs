using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LanguageChange : MonoBehaviour
{
    static public LanguageChange instance;

    [SerializeField]
    private int language;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log(language);
        DontDestroyOnLoad(gameObject);
    }

    public int GetLanguage()
    { 
        return language; 
    }

    void Update()
    {

    }

    public void RussianLanguage()
    {
        Debug.Log($"Test");
        language = 0;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene(0);
    }

    public void EnglishLanguage()
    {
        language = 1;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene(0);
    }

}
