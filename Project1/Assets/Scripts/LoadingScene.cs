using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image LoadBar;
    public TextMeshProUGUI LoadText;
    public int sceneId;

    
    void Start()
    {
        StartCoroutine(LoadSceneCorutine());
    }

   IEnumerator LoadSceneCorutine()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(sceneId);
        while (!asyncOperation.isDone)
        {
            float progress= asyncOperation.progress/0.9f;
            LoadBar.fillAmount = progress;
            LoadText.text="Загрузка "+ string.Format("{0:0%}", progress*100f);
            yield return 0;
        }
    

    }
}
