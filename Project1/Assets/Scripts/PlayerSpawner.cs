using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public List<GameObject> character;
    
    public Vector3 position= new Vector3(150,100,0);

    private int characterId;

    void Awake()
    {
        characterId = PlayerPrefs.GetInt("character");
        Instantiate(character[characterId],position, Quaternion.identity);
    }
}
