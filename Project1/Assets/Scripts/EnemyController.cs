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
    public AudioSource enemyAudio;
    public CameraShake cameraShake;
    

    public Vector3 position= new Vector3 (5.7f,1,0);
    public Vector3 textOffset;
    public Vector3 winTextOffset = new Vector3(-20, 5, 0);

    public bool isAttacked=false;

    void Awake()
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
        textOffset = new Vector3(300, 250, 0);
        

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

        var text = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);

        var oldPos = text.transform.position;
        oldPos += textOffset;
        text.transform.position = oldPos;

       
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
        enemyAudio.Play();
        player.TakeDamage(10f);
        cameraShake.Shake();
    }
}
