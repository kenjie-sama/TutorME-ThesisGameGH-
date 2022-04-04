using System;
using System.Collections.Generic;
using UnityEngine;
using MotionGraphics;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private List<TransitionsObject> transitionsObjects;
    private void Start() => InitializeValues();

    private void InitializeValues()
    {
        foreach (TransitionsObject transformObject in transitionsObjects)
            transformObject.InitializeValues();
    }
    public void SlideInSqaure(int _index, Action action = null) => 
        StartCoroutine(transitionsObjects[_index].TranslateX(callBack: action));
    
    public void SlideOutSqaure(int _index, Action action = null) => 
        StartCoroutine(transitionsObjects[_index].TranslateX(true, callBack: action));
    
    public void ResetSlideIn(int _index, Action action = null) => 
        StartCoroutine(transitionsObjects[_index].TranslateX(true, true, callBack: action));
    
    public void ScaleCircle(int _index, Action action = null) => 
        StartCoroutine(transitionsObjects[_index].ScaleSizeDelta2D(callBack: action));
    
    public void ResetScaleCircle(int index, Action action = null) => 
        StartCoroutine(transitionsObjects[index].ScaleSizeDelta2D(true, true, callBack: action));

    public void ScaleSample(int _index) => StartCoroutine(transitionsObjects[_index].Swipe2D());
    public void ScaleMiddleSample(int _index) => StartCoroutine(transitionsObjects[_index].ScaleSizeDelta2D());

    public void SlideInSample(int _index) => StartCoroutine(transitionsObjects[_index].TranslateX());
    public void ResetSlideSample(int _index) => StartCoroutine(transitionsObjects[_index].TranslateX(true, true));
    public void ResetScaleSample(int _index) => StartCoroutine(transitionsObjects[_index].Swipe2D(true, true));
    public void ResetScaleMiddleSample(int _index) => StartCoroutine(transitionsObjects[_index].ScaleSizeDelta2D(true, true));

    public void PrintInfo(int _index) => transitionsObjects[_index].ShowTransitionInfo();
}
