using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ModalManager : Manager<ModalManager>
{
    [Header("Need Reference")]
    [SerializeField] private RectTransform m_modal;

    [SerializeField] private TextMeshProUGUI m_txtMessage, m_txtDescription, txt_postive, txt_negative;
    [SerializeField] private Button m_btnPositive, m_btnNegative;

    [SerializeField] private GameObject m_modalParent, m_panel;
    [SerializeField] private bool m_inUse = false;

    public bool InUse
    {
        get => m_inUse;
        set => m_inUse = value;
    }

    [Space, Header("Animation Data")]
    [SerializeField] private float m_duration = 1f;
    [SerializeField] private Ease m_inEase = Ease.OutBounce;
    [SerializeField] private Ease m_outEase = Ease.InBounce;

    private void Awake()
    {
        Instance = this;
        m_panel.SetActive(false);
    }

    public void ShowModal(
        string _message, string _description, 
        bool _showPostiveButton = false, string _positiveText = "Yes", 
        bool _showNegativeButton = false, string _negativeText = "No", 
        Action positive_callBack = null, Action negative_callBack = null)
    {
        if (m_inUse)
            return;

        m_modalParent.SetActive(true);
        m_inUse = true;
        
        m_modal.DOScale(1f, m_duration).SetEase(m_inEase);
        m_panel.SetActive(true);

        m_txtMessage.text = _message;
        m_txtDescription.text = _description;
        txt_postive.text = _positiveText;
        txt_negative.text = _negativeText;
        
        m_btnPositive.gameObject.SetActive(_showPostiveButton);
        m_btnNegative.gameObject.SetActive(_showNegativeButton);

        m_btnNegative.onClick.AddListener(HideModal);
        
        if(negative_callBack != null)
            m_btnNegative.onClick.AddListener(() => {
                negative_callBack();
                HideModal();
            });

        if (positive_callBack != null)
            m_btnPositive.onClick.AddListener(() => {
                positive_callBack();
                HideModal();
            });

    }

    public void HideModal()
    {
        if (!m_inUse)
            return;

        m_modal.DOScale(0f, m_duration).SetEase(m_outEase).OnComplete(() =>
        {
            m_txtMessage.text = "";
            m_txtDescription.text = "";
            m_panel.SetActive(false);
            m_inUse = false;
        });
    }
}
