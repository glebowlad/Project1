using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public List<GameObject> character;
    
    public Vector3 position= new Vector3(150,100,0);

    [SerializeField]
    public int CharacterId { get; private set; }


  
    void Awake()
    {
        CharacterId = PlayerPrefs.GetInt("character");
        Instantiate(character[CharacterId],position, Quaternion.identity);
    }
}
