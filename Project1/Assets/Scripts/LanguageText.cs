using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageText : MonoBehaviour
{

    public int language;
    public string[] text;
    private TextMeshProUGUI textLine;

    void Start()
    {
        Console.InputEncoding= Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        language = PlayerPrefs.GetInt("language", language);
        textLine= GetComponent<TextMeshProUGUI>();
        textLine.text= ""+ text[language];
    }

   
}
