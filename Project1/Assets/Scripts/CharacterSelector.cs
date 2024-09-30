using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject warrior;
    public GameObject archer;
    public GameObject mage;

    private Vector3 characterPos;
    private Vector3 characterOutSidePos;

    public void Awake()
    {
        characterPos=warrior.transform.position;
        characterOutSidePos=archer.transform.position;
    }


}
