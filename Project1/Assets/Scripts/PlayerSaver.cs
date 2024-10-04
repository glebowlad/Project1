using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    // Start is called before the first frame update
    public string objectName;
    public int id;

    public void SaveInt()
    {
        PlayerPrefs.SetInt(objectName, id);
    }
}
