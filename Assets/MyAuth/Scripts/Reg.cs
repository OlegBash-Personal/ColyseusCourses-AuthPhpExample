using System;
using System.Collections.Generic;
using UnityEngine;

public class Reg : MonoBehaviour
{
    private const string LOGIN = "login";
    private const string PASS = "password";
    private string _login;
    private string _pass;

    private string _confPass;

    public event Action Error;
    public event Action Success;

    public void SetLogin(string login)
    {
        _login = login;
    }
    public void SetPassword(string password)
    {
        _pass = password;
    }

    public void SetConfPass(string confPass)
    {
        _confPass = confPass;
    }

    public void SingUp()
    {
        if (string.IsNullOrEmpty(_login) ||
        string.IsNullOrEmpty(_pass) ||
        string.IsNullOrEmpty(_confPass))
        {
            ErrorMessage("The login/password is empty");
            return;
        }

        if (_pass != _confPass)
        { ErrorMessage(_pass + " != " + _confPass); return; }

        string uri = UrlLibrary.MAIN + UrlLibrary.REG;
        Dictionary<string, string> data = new Dictionary<string, string>()
        {
            {LOGIN, _login},
            {PASS, _pass}
        };
        Network.Instance.Post(uri, data, SuccessMessage, ErrorMessage);
    }

    private void SuccessMessage(string data)
    {
        if (data != "OK")
        {
            ErrorMessage("Success data: " + data);
            return;
        }

        Debug.Log("Correct!");
        Success?.Invoke();
    }

    private void ErrorMessage(string error)
    {
        Debug.LogError(error);
        Error?.Invoke();
    }
}
