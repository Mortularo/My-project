using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class CreateAccountWindow : AccountDataWindowBase
{
    [SerializeField] private InputField _mailField;
    [SerializeField] private Button _createAccounButton;

    private string _mail;

    protected override void SubscriptionsElementsUI()
    {
        base.SubscriptionsElementsUI();

        _mailField.onValueChanged.AddListener(UpdateMail);
        _createAccounButton.onClick.AddListener(CreateAccount);
    }
    
   private void CreateAccount()
   {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = _username,
            Email = _mail,
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

    private void UpdateMail(string mail)
    {
        _mail = mail;
    }
}
