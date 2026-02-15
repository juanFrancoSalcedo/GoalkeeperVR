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
        positionPresentation[index].Move(presentation);
        yield return new WaitForSeconds(1.1f);
        positionPresentation[index].ActionAfter();
    }
}

[System.Serializable]
public class PositionPresentation
{
    [SerializeField] float yPos;
    [SerializeField] AnimationTextController textController;
    [SerializeField] GameObject[] otherObects;

    public void Move(RectTransform _rectTransform)
    {
        _rectTransform.DOLocalMoveY(yPos, 0.9f).SetEase(Ease.Linear);
    }

    public void ActionAfter() 
    {
        System.Array.ForEach(otherObects,t => t.SetActive(true));
        textController.ActiveAnimation(1);
    }
}
