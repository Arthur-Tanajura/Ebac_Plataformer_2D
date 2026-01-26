using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MenuButtonManager : MonoBehaviour
{
    public System.Collections.Generic.List<GameObject> buttons;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;
    private void Awake()
    {
        HideallButtons();
        ShowButtons();
    }

    private void HideallButtons()
    {
        foreach (var b in buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }


    }

    private void ShowButtons()
    {
        for(int i=0; i<buttons.Count; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i * delay).SetEase(ease);
        }

    }
}

