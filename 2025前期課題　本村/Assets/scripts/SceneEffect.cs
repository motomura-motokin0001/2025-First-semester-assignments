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
        sequence.Append(load.DOFade(0.8f,0.8f).SetLoops(-1,LoopType.Yoyo));

        sequence.AppendInterval(1.3f);

        sequence.Append(EffectImage.DOFade(0f,0.3f));
        sequence.Join(load.DOFade(0f,0.3f).OnComplete(destroy));
    }


    void destroy()
    {
        SceneManager.UnloadSceneAsync(DestroySceneName);
        Debug.Log("destroy～");
    }

}
