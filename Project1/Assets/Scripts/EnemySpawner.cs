using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3 position= new Vector3 (5.7f,1,0);
    void Awake()
    {
        Instantiate(enemyPrefab, position, Quaternion.identity);
        
    }

   
}
