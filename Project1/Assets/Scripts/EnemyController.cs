using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    public GameObject enemyPrefab;
    public GameObject slashPrefab;
    public Slider enemyHealth;
    public int damage = 10;

    public Vector3 position= new Vector3 (5.7f,1,0);
    public Vector3 textOffset = new Vector3(-1, 1, 0);

    void Awake()
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
        
    }

   

    public void TakeDamage()
    {
        Instantiate(slashPrefab, transform.position, Quaternion.identity, transform);
        enemyHealth.value -= damage;
        var text=Instantiate(floatingTextPrefab, position+textOffset, Quaternion.identity,transform);
        text.GetComponent<TextMeshProUGUI>().text="-"+damage.ToString();
    }
   
}
