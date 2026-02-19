using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TutorialPresentationController : MonoBehaviour
{
    [SerializeField] private RectTransform presentation;
    [SerializeField] private PositionPresentation[] positionPresentation;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        CallNext(0);
    }

    public void CallNext(int index)
    {
        StartCoroutine(DoNextCall(index));
    }

    public IEnumerator DoNextCall(int index)
    {
        int before = index - 1;
        if(before>=0)
            positionPresentation[before].Hide();
        yield return new WaitForSeconds(0.7f);
        positionPresentation[index].Move(presentation);
        //positionPresentation[index].ActionAfter();
    }
}

[System.Serializable]
public class PositionPresentation
{
    [SerializeField] AnimationUIController mainAnim;
    [SerializeField] AnimationTextController textController;

    public void Move(RectTransform _rectTransform)
    {
        // dont like this
        mainAnim.transform.parent.gameObject.SetActive(true);
    }

    public void Hide() 
    {
        mainAnim.ActiveAnimation(3);
    }
}
