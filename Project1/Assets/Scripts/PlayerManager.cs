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
    public LanguageChange languageChange;

    [SerializeField] private Vector3 slashPos;
    
    public GameObject prayerPrefab;
    public GameObject slashPrefab;
    public GameObject arrowPrefab;
    public GameObject magicPrefab;
    public GameObject attackPrefab;
    public GameObject floatingTextPrefab;

    public Vector3 damageOffset = new Vector3(-50, 0, 0);
    public Slider health;
    public TextMeshProUGUI text;
    public TextMeshProUGUI attackText;


    public Button prayButton;
    public Button talkButton;
    public Button attackButton;
    public Button restartButton;
    public Button continueButton;

    public bool isAttacked = false;

    public AudioSource swordSound;
    public AudioSource arrowSound;
    public AudioSource spellSound;
    public AudioSource attackSound;
    public AudioSource winSound;
    public AudioSource loseSound;




    void Start()
    {
        restartButton.gameObject.SetActive(false);
        ChooseAttackPrefab();

        restartButton.interactable = false;
        continueButton.interactable = false;
        languageChange = GameObject.FindObjectOfType<LanguageChange>();
    }

    public void ChooseAttackPrefab()
    {

        switch (spawner.CharacterId)
        {
            case 0:

                attackPrefab = slashPrefab;
                attackSound = swordSound;
                break;
            case 1:
                attackPrefab = arrowPrefab;
                attackSound = arrowSound;
                break;
            case 2:
                attackPrefab = magicPrefab;
                attackSound = spellSound;
                break;
            default:
                break;

        }
    }
    public void Attack()
    {
        Instantiate(attackPrefab, slashPos, Quaternion.identity);
        enemy.TakeDamage(10f);
        isAttacked = false;
        attackSound.Play();



        if (enemy.enemyHealth.value <= 0)
        {
            //if (languageChange.language == 0)
            //{
            winSound.Play();
            text.text = " Âû îäîëåëè âðàãà.Ïðîäîëæèòü?";
            attackText.text = "Ïðîäîëæèòü";

            //}
            //else if(languageChange.language == 1) {
            //    text.text = " You win! Continue?";
            //    attackText.text = "Restart";
            //}
            attackButton.interactable = false;
            prayButton.interactable = false;
            talkButton.interactable = false;
            continueButton.interactable = true;


        }
    }
    public void Talk()
    {

        health.value = 0;
        loseSound.Play();
        if (languageChange.GetLanguage() == 0)
        {
            text.text = "Вы проиграли, хотите начать заного?";
        }
        else if (languageChange.GetLanguage() == 1)
        {
            text.text = "You died.Try again?";
            attackText.text = "Restart";
        }

        restartButton.interactable = true;
        attackButton.interactable = false;
        prayButton.interactable = false;
        talkButton.interactable = false;

        restartButton.gameObject.SetActive(true);
    }

    public void Pray()
    {
        Instantiate(prayerPrefab, slashPos, Quaternion.identity);
        health.value = 0;
        //if (languageChange.language == 0)
        //{
        loseSound.Play();
        text.text = "Âû óìåðëè.Íà÷àòü çàíîâî?";
        attackText.text = "Çàíîâî";

        //}
        //else if (languageChange.language == 1)
        //{
        //    text.text = "You died.Try again?";
        //    attackText.text = "Restart";
        //}
        restartButton.interactable = true;
        attackButton.interactable = false;
        prayButton.interactable = false;
        talkButton.interactable = false;




    }

    public void TakeDamage(float damage)
    {
        health.value -= damage;
        isAttacked = true;
        var text = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);



        var oldPos = text.transform.position;
        oldPos.z = 0f;
        oldPos += damageOffset;
        text.transform.position = oldPos;


        text.GetComponent<TextMeshProUGUI>().text = "-" + damage.ToString();
    }
}
