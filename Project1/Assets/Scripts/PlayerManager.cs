using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
    

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject prayerPrefab;
    public GameObject slashPrefab;
    public Vector3 prayOffset = new Vector3(2, 0, 0);
    public Slider health;
    private int damage;
    public TextMeshProUGUI text;

    
 

    public void Attack()
    {
        
    }
    public void Talk()
    {
        
        text.text = "Вы умерли.";
        health.value = 0;
    }

    public void Pray()
    {
        Instantiate(prayerPrefab,transform.position,Quaternion.identity,transform);  
        text.text = "Вы умерли.";
        health.value = 0;

    }
}
