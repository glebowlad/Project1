using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    public GameObject enemyPrefab;
    public GameObject winTextPrefab;
    
    public Slider enemyHealth;
    public PlayerManager player;
    

    public Vector3 position= new Vector3 (5.7f,1,0);
    public Vector3 textOffset = new Vector3(-1, 1, 0);
    public Vector3 winTextOffset = new Vector3(-20, 5, 0);

    public bool isAttacked=false;

    void Awake()
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
        
    }

    private void LateUpdate()
    {
        if (isAttacked == true)
        {
            Invoke("Attack", 3.0f);
            isAttacked = false;  
        }
    }

    public void TakeDamage(float damage)
    {

        enemyHealth.value -= damage;
        isAttacked = true;
        
        var text = Instantiate(floatingTextPrefab, position + textOffset, Quaternion.identity, transform);
        text.GetComponent<TextMeshProUGUI>().text = "-" + damage.ToString();

        if (enemyHealth.value <= 0)
        {
            enemyHealth.value = 0;
            var winText=Instantiate(winTextPrefab, position + winTextOffset, Quaternion.identity, transform);
            winText.GetComponent<TextMeshProUGUI>().text = "Победа";
        }
    }

    public void Attack()
    {
     player.TakeDamage(10f);
    }
}
