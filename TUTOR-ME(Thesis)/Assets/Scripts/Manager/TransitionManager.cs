using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MotionGraphics;

[DisallowMultipleComponent]
public class TransitionManager : MonoBehaviour
{
    [SerializeField] private int start, end;
    [SerializeField] private Button playButton, backbutton;
    
    [SerializeField] private TransitionsObject startTransObj, endTransObj;
    
    [SerializeField] private List<TransitionsObject> transitionsObjects;

    [SerializeField] private GameObject cont_mainMenu, cont_subjectMenu;

    private void Start() => InitializeValues();

    private void InitializeValues()
    {
        playButton?.onClick.AddListener(()=> TwoWayScale(start, false, true));
        backbutton?.onClick.AddListener(()=> TwoWayScale(start, true, false));

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
        
    public void TwoWayScale(int _indexStart, bool enableStartObj, bool enableEndObj)
    {
        startTransObj = transitionsObjects[_indexStart];
        endTransObj = transitionsObjects[_indexStart];

        startTransObj.TransitionObject.SetActive(true);

        StartCoroutine(startTransObj.Swipe2D(callBack: () =>
        {
            endTransObj.TransitionObject.SetActive(true);
            cont_mainMenu.SetActive(enableStartObj);
            cont_subjectMenu.SetActive(enableEndObj);

            StartCoroutine(startTransObj.Swipe2D(true, true, () =>
            {
                startTransObj.TransitionObject.SetActive(false);
                endTransObj.TransitionObject.SetActive(false);
            }));
        }));
    }

    // Experimental Methods
    public void ScaleSample(int _index) => StartCoroutine(transitionsObjects[_index].Swipe2D());
    public void ScaleMiddleSample(int _index) => StartCoroutine(transitionsObjects[_index].ScaleSizeDelta2D());

    public void SlideInSample(int _index) => StartCoroutine(transitionsObjects[_index].TranslateX());
    public void ResetSlideSample(int _index) => StartCoroutine(transitionsObjects[_index].TranslateX(true, true));
    public void ResetScaleSample(int _index) => StartCoroutine(transitionsObjects[_index].Swipe2D(true, true));
    public void ResetScaleMiddleSample(int _index) => StartCoroutine(transitionsObjects[_index].ScaleSizeDelta2D(true, true));

    public void PrintInfo(int _index) => transitionsObjects[_index].ShowTransitionInfo();

    public void ScaleTwoShapeSample(int _indexStart, int _indexEnd)
    {
        startTransObj = transitionsObjects[_indexStart];
        endTransObj = transitionsObjects[_indexEnd];

        startTransObj.ShowTransitionInfo(); // Debug Only
        
        startTransObj.TransitionObject.SetActive(true);

        StartCoroutine(startTransObj.Swipe2D(callBack: () =>
        {
            endTransObj.TransitionObject.SetActive(true);
            endTransObj.ShowTransitionInfo(); // Debug Only
            StartCoroutine(startTransObj.Swipe2D(true, true, () =>
            {
                startTransObj.TransitionObject.SetActive(false);
                endTransObj.TransitionObject.SetActive(false);
            }));
        }));
    }
}
