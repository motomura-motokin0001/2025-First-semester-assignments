using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private string DestroySceneName;
    [SerializeField] private string SceneLoadName;
    [SerializeField] private string EffectSceneName;

    public static int Waiting;//共有変数

    [Range(3, 10)]
    [SerializeField] private int MaxRandomValue = 2;
    public void SceneLoad()
    {

        SceneManager.LoadScene(EffectSceneName, LoadSceneMode.Additive);
        Waiting = Random.Range(2, MaxRandomValue);
        Debug.Log("Waiting time: " + Waiting);
        StartCoroutine(IE());
    }

    IEnumerator IE()
    {
        Debug.Log("IE");
        yield return new WaitForSeconds(Waiting);
        SceneManager.LoadScene(SceneLoadName,LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(DestroySceneName);
        Debug.Log("complete!!");
    }
}
