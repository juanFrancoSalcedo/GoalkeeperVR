using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSponsors : MonoBehaviour
{
    [SerializeField] AnimationUIController center;
    [SerializeField] private Sprite[] spt;
    private int index;
    Image image;
    private IEnumerator Start()
    {
        image = center.GetComponent<Image>();
        while (true) 
        {
            center.ActiveAnimation(0);
            yield return new WaitForSeconds(3f);
            center.ActiveAnimation(1);
            yield return new WaitForSeconds(0.1f);
            index++;
            if(index==spt.Length)
                index = 0;
            image.sprite = spt[index];
        }
    }
}
