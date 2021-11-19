using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuFunctions : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private GameObject menuPanel;
    private void Awake()
    {
        menuPanel.gameObject.SetActive(false);
    }
    void Start()
    {
        menuButton.onClick.AddListener(ShowMenu);
    }

    private void ShowMenu()
    {
        menuPanel.gameObject.SetActive(!menuPanel.gameObject.activeSelf);
    }

}
