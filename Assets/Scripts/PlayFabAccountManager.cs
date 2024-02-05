using TMPro;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
//using PlayFab.ServerModels;

public class PlayFabAccountManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleLabel;

    private void Start()
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), OnGetAccount, OnError);
        //PlayFabClientAPI.GetAccountItems(new GetAccountInfoRequest(), OnGetCatalogSucces, OnError);
        //PlayFabServerAPI.GetRandomResultTables(new GetRandomResultTablesRequest(), OnError);
    }

    private void OnGetCatalogSucces(GetAccountInfoResult result)
    {
        Debug.LogError("OnGetCatalogSucces");
        //ShowItems(result.Catalog);
    }

    private void ShowItems(List<CatalogItem> catalog)
    {
        //Ругается, потому что еще не создан каталог с предметами в плэйфабе

        foreach (var item in catalog)
        {
            Debug.Log($"{item.ItemId}");
        }
    }

    private void OnGetAccount(GetAccountInfoResult result)
    {
        _titleLabel.text = $"PlayFab id: {result.AccountInfo.PlayFabId}";
    }

    private void OnError(PlayFabError error)
    {
        var errorMessage = error.GenerateErrorReport();
        Debug.LogError(errorMessage);
    }
}