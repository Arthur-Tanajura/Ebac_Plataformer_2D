using NUnit.Framework;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class FlashColors : MonoBehaviour
{
   public List<SpriteRenderer> spriterenderers;
   public Color color = Color.red;
   public float duration = .3f;
   private Tween _currentTween;


    private void OnValidate()
    {
        spriterenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriterenderers.Add(child);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Flash();

        }
    }

    public void Flash()
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
            spriterenderers.ForEach(i => i.color =Color.white);
        }

        foreach (var s in spriterenderers)
        {
            s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }




}
