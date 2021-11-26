using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class LoginPanelView : View
{
    [SerializeField] private Button _loginButton;
    [SerializeField] private TextMeshProUGUI _loginID;

    private LoginPanelViewModel _viewModel;

    public void SetViewModel(LoginPanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => 
            {
                _loginButton.gameObject.SetActive(isVisible);
                _loginID.gameObject.SetActive(!isVisible);
            })
            .AddTo(_disposables);

        _viewModel
            .TextID
            .Subscribe((textID) => 
            { 
                _loginID.SetText(textID); 
            })
            .AddTo(_disposables);

        _loginButton.onClick.AddListener(() => {
            _viewModel.LoginButtonPressed.Execute();
        });
    }
}