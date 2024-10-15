using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
    

public class PlayerManager : MonoBehaviour
{
    public EnemyController enemy;
    public PlayerSpawner spawner;
    public MenuManager menuManager;

    public GameObject prayerPrefab;
    public GameObject slashPrefab;
    public GameObject arrowPrefab;
    public GameObject magicPrefab;
    public GameObject attackPrefab;
    public GameObject floatingTextPrefab;

    public Vector3 prayOffset = new Vector3(2, 0, 0);
    public Slider health;
    public TextMeshProUGUI text;
    public TextMeshProUGUI attackText;

    
    public Button prayButton;
    public Button talkButton;
    public Button attackButton;

    public bool isAttacked=false;

    //public bool isAttacked=false;

   void Start()
    {
        ChooseAttackPrefab();
    }

    public void ChooseAttackPrefab()
    {
        switch (spawner.CharacterId)
        {
            case 0 :
                
                attackPrefab = slashPrefab;
                break;
            case 1 :
                attackPrefab = arrowPrefab;
                break;
            case 2 :
                attackPrefab = magicPrefab;
                break;
            default:
                break;
                
        }
    }
    public void Attack()
    {
        Instantiate(attackPrefab, transform.position, Quaternion.identity, transform);
        enemy.TakeDamage(10f);
        isAttacked = false;
        

        if (health.value <= 0)
        {
           attackButton.onClick.AddListener(menuManager.RestartLevel);
        }
        if (enemy.enemyHealth.value <= 0)
        {
            text.text = " Вы одолели врага.Продолжить?";
            attackText.text = "Продолжить";
            prayButton.interactable = false;
            talkButton.interactable = false;

            attackButton.onClick.AddListener(menuManager.End);
        }
    }
    public void Talk()
    {
        
        health.value = 0;
        text.text = "Вы умерли.Начать заново?";
        attackText.text = "Заново";
        prayButton.interactable = false;
        talkButton.interactable = false;
        
      
    }

    public void Pray()
    {
        Instantiate(prayerPrefab,transform.position,Quaternion.identity,transform);  
        health.value = 0;
        text.text = "Вы умерли.Начать заново?";
        attackText.text = "Заново";
        prayButton.interactable = false;
        talkButton.interactable = false;




    }

    public void TakeDamage(float damage)
    {
        health.value -= damage;
        isAttacked = true;
        var text = Instantiate(floatingTextPrefab, transform.position , Quaternion.identity, transform);
        text.GetComponent<TextMeshProUGUI>().text = "-" + damage.ToString();
    }
}
