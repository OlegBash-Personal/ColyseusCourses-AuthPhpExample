using System;
using System.Collections.Generic;
using UnityEngine;

public class Auth : MonoBehaviour
{
    private const string LOGIN = "login";
    private const string PASS = "password";
    private string _login;
    private string _pass;

    public event Action Error;

    public void SetLogin(string login) => _login = login;
    public void SetPassword(string password) => _pass = password;

    public void SingIn()
    {
        if (string.IsNullOrEmpty(_login) || string.IsNullOrEmpty(_pass))
        {
            ErrorMessage("The login/password is empty");
            return;
        }

        string uri = UrlLibrary.MAIN + UrlLibrary.AUTH;
        Dictionary<string, string> data = new Dictionary<string, string>()
        {
            {LOGIN, _login},
            {PASS, _pass}
        };
        Network.Instance.Post(uri, data, Success, ErrorMessage);
    }

    private void Success(string data)
    {
        string[] result = data.Split('|');
        if (result.Length < 2 || result[0] != "OK")
        {
            ErrorMessage("Success data: " + data);
            return;
        }

        if (int.TryParse(result[1], out int id))
        {
            UserInfo.Instance.SetID(id); Debug.Log("Correct! Your ID: " + id);
        }
        else ErrorMessage("Parsing error: " + result + " | " + "Data: " + data);
    }

    private void ErrorMessage(string error)
    {
        Debug.LogError(error);
        Error?.Invoke();
    }
}
