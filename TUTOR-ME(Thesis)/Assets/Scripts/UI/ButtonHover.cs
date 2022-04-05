using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonHover : MonoBehaviour
{
    [SerializeField] private List<RectTransform> buttons;
    [SerializeField] private float scaleSize = 1.3f;
    public void MouseOver(int val) => buttons[val].DOScale(new Vector3(scaleSize, scaleSize, scaleSize), 0.3f).SetEase(Ease.OutCubic);
    public void MouseOut(int val) => buttons[val].DOScale(Vector3.one, 0.3f).SetEase(Ease.OutCubic);
}
