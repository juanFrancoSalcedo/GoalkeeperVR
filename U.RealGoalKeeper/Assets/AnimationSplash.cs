using DG.Tweening;
using UnityEngine;

public class AnimationSplash : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<SpriteRenderer>().DOFade(1,0.7f);
    }

}
