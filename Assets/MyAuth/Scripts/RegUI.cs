using UnityEngine;
using UnityEngine.UI;

public class RegUI : MonoBehaviour
{
    [SerializeField] private Reg _reg;
    [SerializeField] private InputField _login;
    [SerializeField] private InputField _pass;
    [SerializeField] private InputField _confPass;
    [SerializeField] private Button _singUp;
    [SerializeField] private Button _signIn;

    [SerializeField] private GameObject _signInCanvas;
    [SerializeField] private GameObject _signUpCanvas;

    private void Awake()
    {
        _login.onEndEdit.AddListener(_reg.SetLogin);
        _pass.onEndEdit.AddListener(_reg.SetPassword);
        _confPass.onEndEdit.AddListener(_reg.SetConfPass);

        _singUp.onClick.AddListener(SignUpClick);
        _signIn.onClick.AddListener(SignInClick);

        _reg.Error += () =>
        {
            _singUp.gameObject.SetActive(true);
            _signIn.gameObject.SetActive(true);
        };
        _reg.Success += () =>
        {
            _signIn.gameObject.SetActive(true);
        };
    }

    private void SignUpClick()
    {
        _singUp.gameObject.SetActive(false);
        _signIn.gameObject.SetActive(false);

        _reg.SingUp();
    }

    private void SignInClick()
    {
        _signInCanvas.SetActive(true);
        _signUpCanvas.SetActive(false);
    }
}
