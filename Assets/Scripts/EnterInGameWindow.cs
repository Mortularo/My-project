using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterInGameWindow : MonoBehaviour
{
    [SerializeField] private Button _signInButton;
    [SerializeField] private Button _createAccountButton;
    [SerializeField] private Button _enterInGameCanvas;
    [SerializeField] private Button _createAccountCanvas;
    [SerializeField] private Button _signInCanvas;

    void Start()
    {
        _signInButton.onClick.AddListener(OpenSignInWindow);
        _createAccountButton.onClick.AddListener(OpenCreateAccountWindow);
    }

    private void OpenSignInWindow()
    {
        _signInCanvas.enabled = true;
        _enterInGameCanvas.enabled = false;
    }    

    private void OpenCreateAccountWindow()
    {
        _createAccountCanvas.enabled = true;
        _enterInGameCanvas.enabled = false;
    }
}
