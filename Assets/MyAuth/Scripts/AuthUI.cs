using UnityEngine;
using UnityEngine.UI;

public class AuthUI : MonoBehaviour
{
    [SerializeField] private Auth _auth;
    [SerializeField] private InputField _login;
    [SerializeField] private InputField _pass;
    [SerializeField] private Button _signIn;
    [SerializeField] private Button _signUp;

    [SerializeField] private GameObject _signInCanvas;
    [SerializeField] private GameObject _signUpCanvas;

    private void Awake()
    {
        _login.onEndEdit.AddListener(_auth.SetLogin);
        _pass.onEndEdit.AddListener(_auth.SetPassword);

        _signIn.onClick.AddListener(SignInClick);
        _signUp.onClick.AddListener(SignUpClick);

        _auth.Error += () =>
        {
            _signIn.gameObject.SetActive(true);
            _signUp.gameObject.SetActive(true);
        };
    }

    private void SignInClick()
    {
        _signIn.gameObject.SetActive(false);
        _signUp.gameObject.SetActive(false);

        _auth.SingIn();
    }

    private void SignUpClick()
    {
        _signInCanvas.SetActive(false);
        _signUpCanvas.SetActive(true);
    }
}
