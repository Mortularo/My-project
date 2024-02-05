using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
public class PlayFabLogin1 : MonoBehaviour
{
    [SerializeField] private Text _createErrorLabel;
    [SerializeField] private Text _signInErrorLabel;
    private string _mail;
    private string _pass;
    private string _username;

    [SerializeField] private GameObject _loginWin;
    [SerializeField] private GameObject _createWin;
    [SerializeField] private GameObject _optionsWin;

    public void Start()
    {
        _optionsWin.SetActive(true);
        // Here we need to check whether TitleId property is configured in settings or not
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            * If not we need to assign it to the appropriate variable manually
            * Otherwise we can just remove this if statement at all
            */
            PlayFabSettings.staticSettings.TitleId = " A823B";
        }
    }
    public void UpdateUsername(string username)
    {
        _username = username;
    }
    public void UpdateEmail(string mail)
    {
        _mail = mail;
    }
    public void UpdatePassword(string pass)
    {
        _pass = pass;
    }
    public void CreateAccount()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
{
            Username = _username,
            Email = _mail,
            Password = _pass,
            RequireBothUsernameAndEmail = true
        }, OnCreateSuccess, OnFailure);
    }
    public void SignIn()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = _username,
            Password = _pass
        }, OnSignInSuccess, OnFailure);
    }
    public void GoRegistaration()
    {
        _createWin.SetActive(true);
        _loginWin.SetActive(false);
        _optionsWin.SetActive(false);
    }
    public void GoLogin()
    {
        _createWin.SetActive(false);
        _loginWin.SetActive(true);
        _optionsWin.SetActive(false);
    }
    public void Back()
    {
        _createErrorLabel.text = "";
        _signInErrorLabel.text = "";
        _createWin.SetActive(false);
        _loginWin.SetActive(false);
        _optionsWin.SetActive(true);
    }
    private void OnCreateSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log($"Creation Success: {_username}");
    }
    private void OnSignInSuccess(LoginResult result)
    {
        Debug.Log($"Sign In Success: {_username}");
    }
    private void OnFailure(PlayFabError error)
    {
        var errorMessage = error.GenerateErrorReport();
        Debug.LogError($"Something went wrong: {errorMessage}");
        _createErrorLabel.text = errorMessage;
        _signInErrorLabel.text = errorMessage;
    }
}
