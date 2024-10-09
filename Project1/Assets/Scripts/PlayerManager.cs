using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
    

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector3 sliderOffset = new Vector3(0,200,0);
    public Slider health;
    private int damage;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
   

    // Update is called once per frame
    public void Talk()
    {
        
        text.text = "Вы умерли.";
        health.value = 0;
    }

    void Prey()
    {
        
        text.text = "Вы умерли.";
        health.value = 0;

    }
}
