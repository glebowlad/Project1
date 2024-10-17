using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LanguageChange : MonoBehaviour
{
    [SerializeField]
    private int language;
    

   
    void Start()
    {
        Debug.Log(language);

    }

    
    void Update()
    {

    }

    public void RussianLanguage()
    {
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
