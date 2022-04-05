using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class MainMenu : MonoBehaviour
{
    [Header("Need Reference")] 
    [SerializeField] private GameObject container_Options;
    [SerializeField] private RectTransform rectTrans_bgOptions, rectTrans_bgOptionsEndPos;

    [SerializeField] private Button btnOption, btnToMainMenu;
    
    [Space, Header("No Need Reference")] 
    [SerializeField] private Vector2 origPos_bgOptions, endPos_bgOptions;

    [SerializeField] private Image optionsImagePanel;

    [SerializeField] private float duration = 0.3f;
    [SerializeField] private Ease showEase = Ease.OutBounce, hideEase = Ease.InBack;

    private void Awake()
    {
        InitializeValues();
        InitializeListeners();
    }

    private void InitializeListeners()
    {
        btnOption.onClick.AddListener(() => SlideInX(container_Options, rectTrans_bgOptions, endPos_bgOptions.x));
        btnToMainMenu.onClick.AddListener(() => SlideOutX(container_Options, rectTrans_bgOptions, origPos_bgOptions.x));
    }

    private void InitializeValues()
    {
        optionsImagePanel = container_Options.GetComponent<Image>();
        GetPos(rectTrans_bgOptions, rectTrans_bgOptionsEndPos, out origPos_bgOptions, out endPos_bgOptions);
    }
    private void GetPos(RectTransform _origRectTransform, RectTransform _endRectTransform, out Vector2 _origPos, out Vector2 _endPos)
    {
        _origPos = _origRectTransform.position;
        _endPos = _endRectTransform.position;
        Destroy(_endRectTransform.gameObject);
    }

    private void SlideInX(GameObject gameObject, RectTransform rectTransform, float x)
    {
        gameObject.SetActive(true);
        optionsImagePanel.DOFade(0.34f, 0.4f);
        rectTransform.DOMoveX(x, duration).SetEase(showEase);
    }

    private void SlideOutX(GameObject gameObject, RectTransform rectTransform, float x)
    {
        optionsImagePanel.DOFade(0, 0.4f);
        rectTransform.DOMoveX(x, duration).SetEase(showEase).OnComplete(() => gameObject.SetActive(false));
    }
}
