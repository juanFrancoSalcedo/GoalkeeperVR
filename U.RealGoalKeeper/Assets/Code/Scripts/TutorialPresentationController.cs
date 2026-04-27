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

    public void CallPreviouse(int index)
    {
        StartCoroutine(DoPreviouseCall(index));
    }

    public void CallNext(int index)
    {
        StartCoroutine(DoNextCall(index));
    }

    public IEnumerator DoPreviouseCall(int index)
    {
        int after = index +1;
        if (after >= 0)
            positionPresentation[index].Show();
        yield return new WaitForSeconds(0.7f);
        positionPresentation[after].Hide();
        yield return new WaitForSeconds(0.3f);
        positionPresentation[index].ShowButtons();
    }

    public IEnumerator DoNextCall(int index)
    {
        int before = index - 1;
        if(before>=0)
            positionPresentation[before].Hide();
        yield return new WaitForSeconds(0.7f);
        positionPresentation[index].Show();
        yield return new WaitForSeconds(0.3f);
        positionPresentation[index].ShowButtons();
    }
}

[System.Serializable]
public class PositionPresentation
{
    [SerializeField] AnimationUIController mainAnim;
    [SerializeField] AnimationTextController textController;
    [SerializeField] AnimationUIController[] buttons;

    public void ShowButtons() 
    {
        foreach (var button in buttons)
        {
            button.ActiveAnimation(0);
        }
    }

    public void Show()
    {
        // dont like this
        mainAnim.transform.parent.gameObject.SetActive(true);
    }

    public void Hide() 
    {
        mainAnim.ActiveAnimation(3);
        foreach (var button in buttons)
        {
            button.ActiveAnimation(1);
        }
    }
}
