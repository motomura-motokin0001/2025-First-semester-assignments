using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SceneEffect : MonoBehaviour
{
    public Image EffectImage;
    public Image load;
    public string DestroySceneName;

    public void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(EffectImage.DOFade(1f,0.5f));
        sequence.Append(load.DOFillAmount(1f, SceneLoadManager.Waiting)).OnComplete(() =>
        {
            sequence.Append(EffectImage.DOFade(0f,0.3f));
            sequence.Join(load.DOFade(0f,0.3f).OnComplete(destroy));
        });


    }


    void destroy()
    {
        SceneManager.UnloadSceneAsync(DestroySceneName);
        Debug.Log("destroy～");
    }

}
