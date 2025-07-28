using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public string DestroySceneName;
    public string SceneLoadName;
    public string EffectSceneName;
    public float StockTime = 2f;
    public void SceneLoad()
    {
        
        SceneManager.LoadScene(EffectSceneName,LoadSceneMode.Additive);
        
        StartCoroutine(IE());
    }

    IEnumerator IE()
    {
        Debug.Log("IE");
        yield return new WaitForSeconds(StockTime);
        SceneManager.LoadScene(SceneLoadName,LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(DestroySceneName);
        Debug.Log("complete!!");
    }
}
