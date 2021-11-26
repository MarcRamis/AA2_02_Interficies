using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class LoginPanelView : MonoBehaviour
{
    [SerializeField] private Button loginButton;
    [SerializeField] private TextMeshProUGUI ID;

    private LoginPanelViewModel viewModel;

    public void SetViewModel(LoginPanelViewModel _viewModel)
    {
        viewModel = _viewModel;

        viewModel
            .IsVisible
            .Subscribe((isVisible) =>
            {
                loginButton.gameObject.SetActive(isVisible);
                ID.gameObject.SetActive(!isVisible);
            });

        viewModel
            .TextID
            .Subscribe((textID) =>
            {
                ID.SetText(textID);
            });

        loginButton.onClick.AddListener(() =>
        {
            _viewModel.LoginButtonPressed.Execute();
        }
    );
    }
}