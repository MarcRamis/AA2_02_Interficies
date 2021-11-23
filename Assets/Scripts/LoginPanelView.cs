using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class LoginPanelView : MonoBehaviour
{
    [SerializeField] private Button _loginButton;
    //[SerializeField] private TextMeshProUGUI _loginID;

    private LoginPanelViewModel _viewModel;

    public void SetViewModel(LoginPanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => 
            {
                gameObject.SetActive(isVisible);
            });

        _loginButton.onClick.AddListener(() => {
            _viewModel.LoginButtonPressed.Execute();
        }
    );
    }
}