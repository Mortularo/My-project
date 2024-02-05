using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class SignInWindow : AccountDataWindowBase
{
    [SerializeField] private Button _signButton;

    protected override void SubscriptionsElementsUI()
    {
        base.SubscriptionsElementsUI();

        _signButton.onClick.AddListener(SignIn);
    }    

    private void SignIn()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = _username,
            Password = _password
        }, result =>
        {
            Debug.Log($"Succes: {_username}");
            EnterInGameScene();
        }, error =>
        {
            Debug.LogError($"Fail: {error.ErrorMessage}");
        });
    }
}
